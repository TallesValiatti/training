using Azure;
using Azure.AI.OpenAI;
using OpenAI;

namespace VectorSearch.Api.Services;

public class AzureOpenAiService(IConfiguration configuration) : IEmbeddingService
{
    public float[] CreateEmbedding(string text)
    {
        Uri oaiEndpoint = new (configuration.GetSection("AzureOpenAI:Url").Value!);
        string oaiKey = configuration.GetSection("AzureOpenAI:Key").Value!;
        string oaiModel = configuration.GetSection("AzureOpenAI:EmbeddingModel").Value!;

        var client = new AzureOpenAIClient(
            oaiEndpoint, 
            new AzureKeyCredential(oaiKey));
        
        var embeddingClient = client.GetEmbeddingClient(oaiModel);
        
        var returnValue = embeddingClient.GenerateEmbedding(text);
        return returnValue.Value.ToFloats().ToArray();
    }
}