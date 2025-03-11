using Azure;
using Azure.AI.OpenAI;
using ManualRAG.Api.Models;
using OpenAI.Chat;

namespace ManualRAG.Api.Services;

public class RagService(ISearchService searchService, IConfiguration configuration) : IRagService
{
    public string SystemMessage => """
                                   You are an AI assistant that provides responses based on retrieved information. Not your own knowledge.
                                   You must not create any information by yourself.
                                   Your primary role is to ensure that responses are accurate, relevant, and well-structured.
                                   If there ir no data provided, please respond ONLY '[INFO NOT FOUND]'.
                                   At the end of the response, please provide the list of Ids that were used to generate the response.
                                   
                                   Provided data:
                                   {chunks}
                                   """;
    
    public async Task<string> ExecuteAsync(string? text)
    {
        var chunks = await searchService.SearcAsync(text);
        
        Uri oaiEndpoint = new (configuration.GetSection("AzureOpenAI:Url").Value!);
        string oaiKey = configuration.GetSection("AzureOpenAI:Key").Value!;
        string oaiModel = configuration.GetSection("AzureOpenAI:ChatModel").Value!;

        var client = new AzureOpenAIClient(
            oaiEndpoint, 
            new AzureKeyCredential(oaiKey));
        
        var chatClient = client.GetChatClient(oaiModel);

        var systemMessageFormatted = SystemMessage.Replace("{chunks}", JoinChunks(chunks));
        
        List<ChatMessage> messages =
        [
            new SystemChatMessage(
                ChatMessageContentPart.CreateTextPart(systemMessageFormatted)),
            new UserChatMessage(ChatMessageContentPart.CreateTextPart(text))
        ];
        var chatCompletion = await chatClient.CompleteChatAsync(messages);
        var result = chatCompletion.Value.Content[0].Text;  
        return result;
    }

    private string? JoinChunks(List<Chunk> chunks)
    {
        if(chunks.Count == 0)
        {
            return "[NO DATA PROVIDED]";
        }
        
        return string.Join("\n", chunks.Select(chunk => 
            $"""
            ----- Chunks {chunk.Id} ---- 
            {chunk.Text}
            {Environment.NewLine}
            """));
    }
}