using System;
namespace BerkutBotDataCollector.DataAccess.Models
{
    public record BaseEntity
    {
        public Guid Id { get; init; }
        public long TelegramId { get; init; }
        public DateTimeOffset CreatedDateTime { get; init; }
        public DateTimeOffset UpdatedDateTime { get; init; }
    }
}

