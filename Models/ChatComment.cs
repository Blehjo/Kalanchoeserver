using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;


namespace KalanchoeAI.Models
{
	public class ChatComment
	{
        [Key]
        public int Id { get; set; }

		public int? ChatId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? ChatValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimePosted { get; set; }

		public virtual Chat? Chat { get; set; }
	}
}

