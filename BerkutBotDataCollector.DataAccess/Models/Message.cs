using System;
using Microsoft.EntityFrameworkCore;

namespace BerkutBotDataCollector.DataAccess.Models
{
    [Index(nameof(TelegramFromId))]
    [Index(nameof(TelegramChatId))]
    [Index(nameof(SentDateTime))]
    public record Message : BaseEntity
    {
        public Message(long TelegramId) : base(TelegramId)
        {
        }

        public string? Text { get; set; }
        public long TelegramFromId { get; set; }
        public long TelegramChatId { get; set; }
        public MessageType Type { get; set; }
        public DateTimeOffset SentDateTime { get; set; }
        public IList<Photo>? Photo { get; set; }
        public Location? Location { get; set; }
        public string? Caption { get; set; }
    }
}

