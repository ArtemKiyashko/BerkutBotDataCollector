using System;
namespace BerkutBotDataCollector.DataAccess.Models
{
    public record Message(string Text, long TelegramChatId, long TelegramFromId) : BaseEntity;
}

