using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace KalanchoeAI_Backend
{
    public static class GPTCompletions
    {
        public static async Task ArtooTextResponse(IOpenAIService sdk, string prompt)
        {
            try
            {
                var completionResult = await sdk.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = prompt,
                    MaxTokens = 5,
                    LogProbs = 1,
                }, Models.Davinci);

                if (completionResult.Successful)
                {
                    Console.WriteLine(completionResult.Choices.FirstOrDefault());
                }
                else
                {
                    if (completionResult.Error == null)
                    {
                        throw new Exception("Unknown Error");
                    }

                    Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
                }

                Console.WriteLine(completionResult.Choices.FirstOrDefault());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}