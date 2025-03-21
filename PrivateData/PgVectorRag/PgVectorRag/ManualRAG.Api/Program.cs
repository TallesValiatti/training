using ManualRAG.Api.Data;
using ManualRAG.Api.Services;
using Microsoft.EntityFrameworkCore;
using Pgvector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IEmbeddingService, AzureOpenAiService>();
builder.Services.AddScoped<IRagService, RagService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString, o => o.UseVector())
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/ask", async (string? text, IRagService service) => 
        Results.Ok((object?)await service.ExecuteAsync(text)))
.WithName("Ask")
.WithOpenApi();

app.MapPost("/create-embeddings", async (IEmbeddingService embeddingService, AppDbContext appDbContext) =>
    {
        var books = await appDbContext.Chunks.ToListAsync();
        foreach (var book in books)
        {
            if (book.Embedding == null)
            {
                var embedding = embeddingService.CreateEmbedding(book.Text);
                book.Embedding = new Vector(embedding);
            }
            
            await appDbContext.SaveChangesAsync();
        }
        return Results.Ok();
    })
    .WithName("CreateEmbeddings")
    .WithOpenApi();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
dbContext.Database.Migrate();

app.Run();