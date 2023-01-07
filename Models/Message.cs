using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class Message
	{
        [Key]
        public int MessageId { get; set; }

		public int? UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? MessageValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

		public virtual User? User { get; set; }
	}
}

