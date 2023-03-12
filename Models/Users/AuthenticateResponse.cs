using KalanchoeAI_Backend.Models;

namespace KalanchoeAI_Backend.Models.Users
{
	public class AuthenticateResponse
	{
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}

