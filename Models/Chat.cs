using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI.Models
{
	public class Chat
	{
        public int Id { get; set; }

		public int UserId { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public User User { get; set; }

		public ICollection<ChatComment>? ChatComments { get; set; }
    }
}
