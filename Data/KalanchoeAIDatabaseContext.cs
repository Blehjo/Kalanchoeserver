using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KalanchoeAI.Models;

namespace KalanchoeAI.Data
{
	public class KalanchoeAIDatabaseContext : DbContext
	{
		public KalanchoeAIDatabaseContext(DbContextOptions<KalanchoeAIDatabaseContext> options)
                : base(options)
		{
        }

		public DbSet<KalanchoeAI.Models.User> Users { get; set; } 
		public DbSet<KalanchoeAI.Models.Follower> Followers { get; set; }
        public DbSet<KalanchoeAI.Models.Chat> Chats { get; set; } 
        public DbSet<KalanchoeAI.Models.ChatComment> ChatComments { get; set; } 
        public DbSet<KalanchoeAI.Models.Post> Posts { get; set; } 
        public DbSet<KalanchoeAI.Models.Comment> Comments { get; set; }
        public DbSet<KalanchoeAI.Models.Community> Communities { get; set; }
        public DbSet<KalanchoeAI.Models.Member> Members { get; set; } 
        public DbSet<KalanchoeAI.Models.Channel> Channels { get; set; } 
        public DbSet<KalanchoeAI.Models.ChannelComment> ChannelComments { get; set; } 
        public DbSet<KalanchoeAI.Models.Message> Messages { get; set; } 
        public DbSet<KalanchoeAI.Models.Panel> Panels { get; set; } 
        public DbSet<KalanchoeAI.Models.Note>? Note { get; set; }
    }
}