using System;
namespace BerkutBotDataCollector.DataAccess.Models
{
    public record Chat : BaseEntity
    {
        public Chat(long TelegramId) : base(TelegramId)
        {
        }

        public string? Title { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Username { get; set; }
    }
}

