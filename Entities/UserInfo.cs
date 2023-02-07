using System.Text.Json.Serialization;

namespace KalanchoeAI_Backend.Entities
{
	public class UserInfo
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}