using System;
namespace BerkutBotDataCollector.DataAccess.Models
{
    public record Message : BaseEntity
    {
        public Message(long TelegramId) : base(TelegramId)
        {
        }

        public string Text { get; set; }
        public long TelegramFromId { get; set; }
        public long TelegramChatId { get; set; }
    }
}

