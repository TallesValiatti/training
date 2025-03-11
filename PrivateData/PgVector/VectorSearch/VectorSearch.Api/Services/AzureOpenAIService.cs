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
        string oaiModel = configuration.GetSection("AzureOpenAI:Model").Value!;

        var client = new AzureOpenAIClient(
            oaiEndpoint, 
            new AzureKeyCredential(oaiKey));
        
        var embeddingClient = client.GetEmbeddingClient("text-embedding-ada-002");
        
        var returnValue = embeddingClient.GenerateEmbedding(text);
        return returnValue.Value.ToFloats().ToArray();
    }
}