using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerkutBotDataCollector.DataAccess.Models
{
    [Table("Photos")]
    public record Photo : FileBase
	{
        public int Width { get; set; }
        public int Height { get; set; }
    }
}

