using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI_Backend.Models
{
	
	public class Follower
	{
		public int FollowerId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
	}
}

