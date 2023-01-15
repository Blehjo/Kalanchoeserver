using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class Post
	{
        public int? PostId { get; set; }

		public int? UserId { get; set; }

		public string? PostValue { get; set; }

		public string? MediaLink { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

		public virtual User? User { get; set; }

		public virtual ICollection<Comment>? Comments { get; set; }
	}
}

