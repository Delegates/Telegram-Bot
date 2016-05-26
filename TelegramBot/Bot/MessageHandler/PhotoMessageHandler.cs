using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Handler
{
    public class PhotoMessageHandler : IMessageHandler
    {

        public void ProcessTheMessage(Message message, IApi api, User user)
        {
            api.SendTextMessage(message.Chat.Id, "wow such cool photo");
        }
    }
}