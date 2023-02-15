using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalanchoeAI_Backend.Models
{
	public class Note
	{
        public int NoteId { get; set; }

        public string NoteValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public int PanelId { get; set; }
        public Panel? Panel { get; set; }
	}
}

