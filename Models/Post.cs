using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace KalanchoeAI_Backend.Models
{
	public class Post
	{
        public int PostId { get; set; }

		public string? PostValue { get; set; }

		[NotMapped]
        public IFormFile? MediaLink { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }

		public User? User { get; set; }

		public ICollection<Comment>? Comments { get; set; }
	}
}

