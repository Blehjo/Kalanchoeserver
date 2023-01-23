using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI.Models
{
	
	public class Follower
	{
		public int UserId { get; set; }

		public int FollowerId { get; set; }

		public User User { get; set; }
	}
}

