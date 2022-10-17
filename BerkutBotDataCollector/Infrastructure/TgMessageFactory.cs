using System;
using BerkutBotDataCollector.Helpers;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Infrastructure
{
    public class TgMessageFactory : ITgMessageFactory
    {
        public Message GetMessage(Update incomingUpdate) => incomingUpdate?.Type switch
        {
            Telegram.Bot.Types.Enums.UpdateType.Message => incomingUpdate.Message,
            Telegram.Bot.Types.Enums.UpdateType.EditedMessage => incomingUpdate.EditedMessage,
            Telegram.Bot.Types.Enums.UpdateType.CallbackQuery => incomingUpdate.CallbackQuery.FormatCallbackMessage(),
            _ => null
        };

        public Chat GetChat(Update incomingUpdate) => incomingUpdate?.Type switch
        {
            Telegram.Bot.Types.Enums.UpdateType.Message => incomingUpdate.Message.Chat,
            Telegram.Bot.Types.Enums.UpdateType.EditedMessage => incomingUpdate.EditedMessage.Chat,
            Telegram.Bot.Types.Enums.UpdateType.MyChatMember => incomingUpdate.MyChatMember.Chat,
            _ => null
        };
    }
}

