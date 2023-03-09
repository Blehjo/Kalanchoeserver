using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace KalanchoeAI_Backend.Models
{
	public class User
	{
        public int UserId { get; set; }

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

        public string? About { get; set; }

        [NotMapped]
        public IFormFile? ProfileImage { get; set; }

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