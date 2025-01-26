namespace KernelMemory.Models;

public record AskResponse(string Response, IEnumerable<string> Sources);