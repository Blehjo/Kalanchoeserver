using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class Member
	{
        [Key]
        public int MemberId { get; set; }

		public int? CommunityId { get; set; }

		public int? UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateLeft { get; set; }

		public virtual Community? Community { get; set; }

		public virtual User? User { get; set; }
	}
}

