using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI_Backend.Models
{
	public class ChannelComment
	{
        public int Id { get; set; }

		public int ChannelId { get; set; }

		public int UserId { get; set; }

        public string? ChannelCommentValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public Channel Channel { get; set; }

        public User User { get; set; }
    }
}

