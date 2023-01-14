using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;

namespace KalanchoeAI_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatgptController : ControllerBase
    {
        //var openAiService = serviceProvider.GetRequiredService<IOpenAIService>();
        //openAiService.SetDefaultEngineId(Engines.Davinci);
        

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
        public void Post([FromBody] string value)
        {
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
