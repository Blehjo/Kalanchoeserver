using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace KalanchoeAI.Models
{
	
	public class Follower
	{
		public int? UserId { get; set; }

		public int? FollowerId { get; set; }

		public virtual User? User { get; set; }
	}
}

