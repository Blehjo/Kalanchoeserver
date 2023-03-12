using System.ComponentModel.DataAnnotations;

namespace KalanchoeAI_Backend.Models.Users
{
	public class AuthenticateRequest
	{
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

