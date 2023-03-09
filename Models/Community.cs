using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KalanchoeAI_Backend.Models
{
    public class Community
	{
        public int CommunityId { get; set; }

        public string GroupName { get; set; }

        public string Description { get; set; }

        public string? MediaLink { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string ImageSource { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public User? User { get; set; }

		public ICollection<Member>? Members { get; set; }

		public ICollection<Channel>? Channels { get; set; }
	}
}

