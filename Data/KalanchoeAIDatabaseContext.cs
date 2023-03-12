using Microsoft.EntityFrameworkCore;
using KalanchoeAI_Backend.Models;
using KalanchoeAI_Backend.Models.Users;
using System.Reflection.Metadata;

namespace KalanchoeAI_Backend.Data
{
	public class KalanchoeAIDatabaseContext : DbContext
	{
		public KalanchoeAIDatabaseContext(DbContextOptions<KalanchoeAIDatabaseContext> options)
                : base(options)
		{
            Database.EnsureCreated();
            //Database.GetMigrations();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatComment> ChatComments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelComment> ChannelComments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageComment> MessageComments { get; set; }
        public DbSet<Panel> Panels { get; set; } 
        public DbSet<Note> Note { get; set; }
        public DbSet<Saved> Saved { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}