using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerkutBotDataCollector.DataAccess.Models
{
    [Table("Locations")]
	public record Location
	{
        public Guid Id { get; init; } = Guid.NewGuid();
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public float? HorizontalAccuracy { get; set; }
        public int? LivePeriod { get; set; }
        public int? Heading { get; set; }
        public int? ProximityAlertRadius { get; set; }
    }
}

