using System;
namespace BerkutBotDataCollector.DataAccess.Models
{
    public record BaseEntity(long TelegramId)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTimeOffset CreatedDateTime { get; init; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedDateTime { get; set; } = DateTimeOffset.Now;
    }
}

