using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class ChannelComment
	{
        [Key]
        public int ChannelCommentId { get; set; }

		public int? ChannelId { get; set; }

		public int? UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? ChannelCommentValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

        public virtual Channel? Channel { get; set; }
	}
}

