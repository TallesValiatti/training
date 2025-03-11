using System.Text.Json.Serialization;
using Pgvector;

namespace ManualRAG.Api.Models;

public class Chunk
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
    
    [JsonIgnore]
    public Vector? Embedding { get; set; }
}