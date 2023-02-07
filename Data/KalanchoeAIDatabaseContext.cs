using Microsoft.EntityFrameworkCore;
using KalanchoeAI_Backend.Models;
using System.Reflection.Metadata;

namespace KalanchoeAI_Backend.Data
{
	public class KalanchoeAIDatabaseContext : DbContext
	{
		public KalanchoeAIDatabaseContext(DbContextOptions<KalanchoeAIDatabaseContext> options)
                : base(options)
		{
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
        public DbSet<Panel> Panels { get; set; } 
        public DbSet<Note> Note { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Panel>()
                .Property<int>("UserId");
            modelBuilder.Entity<Panel>()
                .HasOne(p => p.User)
                .WithMany(u => u.Panels)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Panel>()
                .Navigation(b => b.User)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
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