using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;
using Azure;
using Microsoft.Identity.Client;

namespace KalanchoeAI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatgptController : ControllerBase
    {

        string ApiKey = "";
        string response = "";
        string Organization = "";
        IConfiguration _configuration;

        // GET: api/Chatgpt
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Chatgpt/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Chatgpt
        [HttpPost]
        public async Task PostAsync()
        {
            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = _configuration["OpenAIServiceOptions:ApiKey"],
                Organization = _configuration["OpenAIServiceOptions:Organization"]
            });

            var completionResult = await openAiService.Completions
            .CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = "hello",
                MaxTokens = 5
            }, Models.Davinci);
            if (completionResult.Successful)
            {
                response = completionResult
                .Choices.FirstOrDefault()?.Text ?? "";
            }
            else
            {
                if (completionResult.Error == null)
                {
                    response = "Unknown Error";
                }
                response =
                $"{completionResult.Error?.Code}: {completionResult.Error?.Message}";
            }
        }

        // PUT: api/Chatgpt/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Chatgpt/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
