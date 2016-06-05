using System.Drawing;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Handler
{
    public class PhotoHandler
    {

        public UniveralBot.Message ProcessTheMessage(Image message, string chatId)
        {
            return new UniveralBot.Message(UniveralBot.MessageType.Text, "wow such cool photo",chatId);
        }
    }
}