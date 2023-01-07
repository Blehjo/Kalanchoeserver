using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class Panel
	{
        [Key]
        public int PanelId { get; set; }

		public int? UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

		public virtual User? User { get; set; }

		public virtual ICollection<Note>? Notes { get; set; }
	}
}

