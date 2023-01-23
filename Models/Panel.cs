using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI.Models
{
	public class Panel
	{
        public int Id { get; set; }

        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int UserForeignKey { get; set; }
        public User User { get; set; }

		public ICollection<Note>? Notes { get; set; }
	}
}

