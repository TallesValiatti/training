namespace ManualRAG.Api.Services;

public interface IEmbeddingService
{
    public float[] CreateEmbedding(string text);
}