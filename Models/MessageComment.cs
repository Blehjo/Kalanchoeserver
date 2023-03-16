using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI_Backend.Models
{
	public class MessageComment
	{
        public int MessageCommentId { get; set; }

        public string MessageValue { get; set; }

        public string? MediaLink { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public string? ImageSource { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int MessageId { get; set; }
        public Message? Message { get; set; }
    }
}