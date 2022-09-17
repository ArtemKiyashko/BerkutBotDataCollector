using System;
using Telegram.Bot.Types;

namespace BerkutBotDataCollector.Helpers
{
    public static class CallBackQueryExtensions
    {
        public static Message FormatCallbackMessage(this CallbackQuery tgCallbackQuery)
        {
            tgCallbackQuery.Message.Text = tgCallbackQuery.Data;
            return tgCallbackQuery.Message;
        }
    }
}

