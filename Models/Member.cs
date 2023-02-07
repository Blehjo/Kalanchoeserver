using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI_Backend.Models
{
	public class Member
	{
        public int Id { get; set; }

		public int CommunityId { get; set; }

		public int UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public Community Community { get; set; }

		public User User { get; set; }
	}
}

