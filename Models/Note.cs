using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace KalanchoeAI.Models
{
	public class Note
	{
        [Key]
        public int NoteId { get; set; }

		public int? PanelId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? NoteValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

		public virtual Panel? Panel { get; set; }
	}
}

