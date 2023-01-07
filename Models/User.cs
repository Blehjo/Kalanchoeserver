using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class User
	{
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Username { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        private string? LastName { get; set; }

        [DataType(DataType.Date)]
        private DateTime DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? EmailAddress { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Password { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? About { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? ProfileImage { get; set; }

        [DataType(DataType.Date)]
        public DateTime Joined { get; set; }

        public virtual ICollection<Chat>? Chats { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual ICollection<Community>? Communities { get; set; }

        public virtual ICollection<Member>? Members { get; set; }

        public virtual ICollection<Message>? Messages { get; set; }

        public virtual ICollection<Panel>? Panels { get; set; }

        public virtual ICollection<Follower>? Followers { get; set; }
    }
}