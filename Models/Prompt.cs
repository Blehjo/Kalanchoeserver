using KalanchoeAI_Backend.Models;

namespace KalanchoeAI_Backend.Models
{
	public class Prompt
	{
        public int PromptId { get; set; }
        public string Request { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }
    }
}

