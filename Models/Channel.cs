using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI.Models
{
	public class Channel
	{
        public int Id { get; set; }

		public int CommunityId { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public Community Community { get; set; }

		public ICollection<ChannelComment>? ChannelComments { get; set; }
	}
}

