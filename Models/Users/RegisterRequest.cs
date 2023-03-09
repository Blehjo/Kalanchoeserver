using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace KalanchoeAI_Backend.Models.Users
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        private DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public IFormFile ProfileImage { get; set; }
    }
}