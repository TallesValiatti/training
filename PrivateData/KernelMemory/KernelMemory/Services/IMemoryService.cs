using KernelMemory.Models;

namespace KernelMemory.Services;

public interface IMemoryService
{
    Task ImportTextAsync(Text text);
    Task ImportWebPageAsync(WebPage webPage);
    Task<AskResponse> AskAsync(string question);
}
