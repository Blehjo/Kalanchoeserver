using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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

        public IFormFile? FormFile { get; set; }
    }
}

