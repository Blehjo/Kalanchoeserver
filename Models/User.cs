using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI.Models
{
	public class User
	{
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        private string? LastName { get; set; }

        [DataType(DataType.Date)]
        private DateTime DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        public string? Password { get; set; }

        public string? About { get; set; }

        public string? ProfileImage { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public ICollection<Chat>? Chats { get; set; }

        public ICollection<Post>? Posts { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public ICollection<Community>? Communities { get; set; }

        public ICollection<Member>? Members { get; set; }

        public ICollection<Message>? Messages { get; set; }

        public ICollection<Panel>? Panels { get; set; }

        public ICollection<Follower>? Followers { get; set; }

        public ICollection<ChannelComment>? ChannelComments { get; set; }
    }
}