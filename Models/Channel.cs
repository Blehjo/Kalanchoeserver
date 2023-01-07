using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class Channel
	{
        [Key]
        public int ChannelId { get; set; }

		public int? CommunityId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

		public virtual Community? Community { get; set; }

		public virtual ICollection<ChannelComment>? ChannelComments { get; set; }
	}
}

