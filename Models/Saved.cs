using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace KalanchoeAI_Backend.Models
{
	public class Saved
	{
		public int SavedId { get; set; }

		public string? Title { get; set; }

		public string? Link { get; set; }

		[NotMapped]
        public IFormFile? MediaLink { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }

		public User? User { get; set; }
	}
}

