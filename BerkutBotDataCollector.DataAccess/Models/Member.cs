using System;
namespace BerkutBotDataCollector.DataAccess.Models
{
    public record Member : BaseEntity
    {
        public Member(long TelegramId) : base(TelegramId)
        {
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public bool IsBot { get; set; }
        public string? LanguageCode { get; set; }
    }
}

