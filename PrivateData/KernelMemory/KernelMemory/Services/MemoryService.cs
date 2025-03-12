using KernelMemory.Models;
using Microsoft.KernelMemory;

namespace KernelMemory.Services;

public class MemoryService : IMemoryService
{
    private readonly IKernelMemory _kernelMemory;

    public MemoryService(IConfiguration configuration)
    {
        _kernelMemory = CreateKernelMemory(configuration);
    }

    public async Task ImportTextAsync(Text text)
    {
        await _kernelMemory.ImportTextAsync(
            text.Content,
            documentId: text.Name);
    }

    public async Task ImportWebPageAsync(WebPage webPage)
    {
        await _kernelMemory.ImportWebPageAsync(
            webPage.Url,
            documentId: webPage.Name);
    }
    
    public async Task<AskResponse> AskAsync(string question)
    {
        var result = await _kernelMemory.AskAsync(question);
        
        return new AskResponse(
            result.Result, 
            result.RelevantSources.Select(x => x.DocumentId));
    }
    
    private IKernelMemory CreateKernelMemory(IConfiguration configuration)
    {
        var key = configuration["AzureOpenAi:Key"]!;
        var endpoint = configuration["AzureOpenAi:Endpoint"]!;
        var textModel = configuration["AzureOpenAi:TextModel"]!;
        var embeddingModel = configuration["AzureOpenAi:EmbeddingModel"]!;

        var embeddingConfig = new AzureOpenAIConfig
        {
            APIKey = key,
            Deployment = embeddingModel,
            Endpoint = endpoint,
            APIType = AzureOpenAIConfig.APITypes.EmbeddingGeneration,
            Auth = AzureOpenAIConfig.AuthTypes.APIKey
        };

        var chatConfig = new AzureOpenAIConfig
        {
            APIKey = key,
            Deployment = textModel,
            Endpoint = endpoint,
            APIType = AzureOpenAIConfig.APITypes.ChatCompletion,
            Auth = AzureOpenAIConfig.AuthTypes.APIKey
        };

        return new KernelMemoryBuilder()
            .WithAzureOpenAITextGeneration(chatConfig)
            .WithAzureOpenAITextEmbeddingGeneration(embeddingConfig)
            .WithSimpleVectorDb() // Memory
            .Build<MemoryServerless>();
            // .WithQdrantMemoryDb("http://localhost:6333") // Qdrant
            // .Build<MemoryServerless>(new KernelMemoryBuilderBuildOptions
            // {
            //     AllowMixingVolatileAndPersistentData = true
            // });
    }
}