using ManualRAG.Api.Data;
using ManualRAG.Api.Models;
using Microsoft.EntityFrameworkCore;
using Pgvector;
using Pgvector.EntityFrameworkCore;

namespace ManualRAG.Api.Services;

public class SearchService(AppDbContext appDbContext, IEmbeddingService embeddingService, IConfiguration configuration) : ISearchService
{
    public async Task<List<Chunk>> SearcAsync(string? text)
    {
        var query = appDbContext.Chunks.AsQueryable();

        if (!string.IsNullOrWhiteSpace(text))
        {
            var searchThreshold = configuration.GetValue<double>("Application:SearchThreshold");
            
            // Embeddings
            var embedding = embeddingService.CreateEmbedding(text);
            var embeddingVector = new Vector(embedding);

            query = query
                .Where(x => x.Embedding!.CosineDistance(embeddingVector) <= searchThreshold)
                .OrderBy(x => x.Embedding!.CosineDistance(embeddingVector))
                .Take(5);
        }
        
        return await query.ToListAsync();
    }
}