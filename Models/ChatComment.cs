using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI_Backend.Models
{
	public class ChatComment
	{
        public int ChatCommentId { get; set; }

        public string ChatValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
	}
}

