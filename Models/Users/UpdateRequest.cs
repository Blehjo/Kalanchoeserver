using System.ComponentModel.DataAnnotations;

namespace KalanchoeAI_Backend.Models.Users
{
    public class UpdateRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [DataType(DataType.Date)]
        private DateTime DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string About { get; set; }

        public string ProfileImage { get; set; }
    }
}

