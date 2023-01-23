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
        public DbSet<KalanchoeAI.Models.Note> Note { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Panel>()
                .Property<int>("UserId");
            modelBuilder.Entity<Panel>()
                .HasOne(p => p.User)
                .WithMany(u => u.Panels)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Chats)
            //    .WithOne(c => c.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Communities)
            //    .WithOne(c => c.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Followers)
            //    .WithOne(f => f.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Messages)
            //    .WithOne(m => m.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Panel>()
            //    .HasOne(p => p.User)
            //    .WithMany(u => u.Panels)
            //    .HasForeignKey(p => p.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Posts)
            //    .WithOne(p => p.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Members)
            //    .WithOne(m => m.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Comments)
            //    .WithOne(c => c.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.ChannelComments)
            //    .WithOne(c => c.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Chat>()
            //    .HasMany(c => c.ChatComments)
            //    .WithOne(c => c.Chat)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Community>()
            //    .HasMany(c => c.Channels)
            //    .WithOne(c => c.Community)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Community>()
            //    .HasMany(c => c.Members)
            //    .WithOne(m => m.Community)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Panel>()
            //    .HasMany(p => p.Notes)
            //    .WithOne(n => n.Panel)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Post>()
            //    .HasMany(p => p.Comments)
            //    .WithOne(c => c.Post)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Channel>()
            //    .HasMany(c => c.ChannelComments)
            //    .WithOne(c => c.Channel)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Note>();
            //modelBuilder.Entity<Message>();
            //modelBuilder.Entity<Member>();
            //modelBuilder.Entity<Follower>();
            //modelBuilder.Entity<ChatComment>();
            //modelBuilder.Entity<ChannelComment>();
        }
    }
}