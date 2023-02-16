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
using KalanchoeAI_Backend.Models;

namespace KalanchoeAI_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatgptController : ControllerBase
    {

        private string ApiKey;
        private string response;
        private string Organization;
        private IConfiguration _configuration;

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
        public async Task<ActionResult<string>> PostAsync(Models.Prompt prompt)
        {
            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = "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"
            });

            var completionResult = await openAiService.Completions
            .CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt.Request,
                MaxTokens = 50
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
