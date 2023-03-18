using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;


namespace KalanchoeAI_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatgptController : ControllerBase
    {

        private string ApiKey;
        private string response;
        private string Organization;
        private IConfiguration configuration;

        [HttpPost("completion")]
        public async Task<ActionResult<string>> PostCompletion(Models.Prompt prompt)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            string apiKey = null;

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey
            });

            var completionResult = await openAiService.Completions
            .CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt.Request,
                MaxTokens = 256
            }, OpenAI.Engine.Davinci);
            if (completionResult.Successful)
            {
                response = completionResult
                .Choices.FirstOrDefault()?.Text ?? "";
                return response;
            }
            else
            {
                if (completionResult.Error == null)
                {
                    response = "Unknown Error";
                }
                response =
                $"{completionResult.Error?.Code}: {completionResult.Error?.Message}";
                return response;
            }
        }

        // POST: api/Chatgpt
        [HttpPost("dalle")]
        public async Task<ActionResult<string>> PostDalle(Models.Prompt prompt)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            string apiKey = null;

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey
            });

            var imageResult = await openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = prompt.Request,
                N = 4,
                Size = StaticValues.ImageStatics.Size.Size512,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "TestUser"
            });
            if (imageResult.Successful)
            {
                Console.WriteLine(string.Join("\n", imageResult.Results.Select(r => r.Url)));
                return string.Join("\n", imageResult.Results.Select(r => r.Url));
            }
            return "Try again";
        }

        [HttpPost("code")]
        public async Task<ActionResult<string>> PostCode(Models.Prompt prompt)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            string apiKey = null;

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey
            });

            var completionResult = await openAiService.Completions
            .CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt.Request,
                MaxTokens = 256,
            }, OpenAI.GPT3.ObjectModels.Models.CodeDavinciV2);
            if (completionResult.Successful)
            {
                response = completionResult
                .Choices.FirstOrDefault()?.Text ?? "";
                return response;
            }
            else
            {
                if (completionResult.Error == null)
                {
                    response = "Unknown Error";
                }
                response =
                $"{completionResult.Error?.Code}: {completionResult.Error?.Message}";
                return response;
            }
        }

        [HttpPost("artoo")]
        public async Task<ActionResult<string>> Artoo(Models.Prompt prompt)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            string apiKey = null;

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apiKey
            });

            var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
            {
                ChatMessage.FromUser(prompt.Request)
            },
                Model = OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo,
                MaxTokens = 256
            });
            if (completionResult.Successful)
            {
                response = completionResult.Choices.First().Message.Content;
                return response;
            }
            else
            {
                if (completionResult.Error == null)
                {
                    response = "Unknown Error";
                }
                response =
                $"{completionResult.Error?.Code}: {completionResult.Error?.Message}";
                return response;
            }
        }
    }
}
