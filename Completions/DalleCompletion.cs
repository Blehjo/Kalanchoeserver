using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace KalanchoeAI_Backend.Completions
{
	public class DalleCompletion
	{
        public static async Task ArtooImageResponse(IOpenAIService sdk, string prompt)
        {

            var imageResult = await sdk.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = prompt,
                N = 2,
                Size = StaticValues.ImageStatics.Size.Size256,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "TestUser"
            });


            if (imageResult.Successful)
            {
                Console.WriteLine(string.Join("\n", imageResult.Results.Select(r => r.Url)));
            }
        }
    }
}

