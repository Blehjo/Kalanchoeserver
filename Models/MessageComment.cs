using System;
using System.ComponentModel.DataAnnotations;

namespace KalanchoeAI_Backend.Models
{
	public class MessageComment
	{
        public int MessageCommentId { get; set; }

        public string MessageValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int MessageId { get; set; }
        public Message? Message { get; set; }
    }
}

