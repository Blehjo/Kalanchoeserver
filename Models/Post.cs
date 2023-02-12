using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI_Backend.Models
{
	public class Post
	{
        public int Id { get; set; }

		public string? PostValue { get; set; }

		public string? MediaLink { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        //public int? UserId { get; set; }

        //public User User { get; set; }

		public ICollection<Comment>? Comments { get; set; }
	}
}

