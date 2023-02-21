using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI_Backend.Models
{
	public class Channel
	{
        public int ChannelId { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int CommunityId { get; set; }
        public Community? Community { get; set; }

		public ICollection<ChannelComment>? ChannelComments { get; set; }
	}
}

