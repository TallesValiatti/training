using KernelMemory.Models;
using KernelMemory.Services;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMemoryService, MemoryService>();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();

app.MapPost("/import-text", async (Text text, [FromServices] IMemoryService memoryService) =>
{
    await memoryService.ImportTextAsync(text);
    return Results.Ok();
})
.WithName("ImportText")
.WithOpenApi();

app.MapPost("/import-web-page", async (WebPage url, [FromServices] IMemoryService memoryService) =>
    {
        await memoryService.ImportWebPageAsync(url);
        return Results.Ok();
    })
    .WithName("ImportWebPage")
    .WithOpenApi();

app.MapGet("/ask", async (string question, [FromServices] IMemoryService memoryService) =>
{
    return Results.Ok(await memoryService.AskAsync(question));
})
.WithName("Ask")
.WithOpenApi();

app.Run();
