using ManualRAG.Api.Models;

namespace ManualRAG.Api.Services;

public interface ISearchService
{
    public Task<List<Chunk>> SearcAsync(string? text);
}