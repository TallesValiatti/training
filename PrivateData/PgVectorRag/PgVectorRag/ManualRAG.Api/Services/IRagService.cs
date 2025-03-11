namespace ManualRAG.Api.Services;

public interface IRagService
{
    public Task<string> ExecuteAsync(string? text);
}