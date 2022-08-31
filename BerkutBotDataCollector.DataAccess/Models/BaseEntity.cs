using System;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Models
{
    [Index(nameof(TelegramId), IsUnique = true)]
    [Index(nameof(CreatedDateTime))]
    [Index(nameof(UpdatedDateTime))]
    public record BaseEntity(long TelegramId)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTimeOffset CreatedDateTime { get; init; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedDateTime { get; set; } = DateTimeOffset.Now;
    }
}

