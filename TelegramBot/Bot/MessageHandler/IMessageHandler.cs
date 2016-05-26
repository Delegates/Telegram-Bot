using System.Collections.Generic;
using System.Data;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Handler
{
    public interface IMessageHandler
    {
        void ProcessTheMessage(Message message,IApi api, User user);
    }
}