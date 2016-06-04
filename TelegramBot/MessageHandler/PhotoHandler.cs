using System.Drawing;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Handler
{
    public class PhotoHandler
    {

        public UniveralBot.Message ProcessTheMessage(Image message)
        {
            //   api.SendTextMessage(message.Chat.Id, "wow such map much location");

            return new UniveralBot.Message(UniveralBot.MessageType.Text, "wow such cool photo");
        }
    }
}