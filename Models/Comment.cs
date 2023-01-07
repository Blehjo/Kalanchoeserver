using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class Comment
	{
        [Key]
        public int CommentId { get; set; }

		public int? UserId { get; set; }

		public int? PostId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? CommentValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

		public virtual User? User { get; set; }

		public virtual Post? Post { get; set; }
	}
}

