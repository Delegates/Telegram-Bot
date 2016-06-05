using Telegram.Bot.Types;
using Message = UniveralBot.Message;

namespace TelegramBot
{
    public static class Converter
    {
        public static Message UpdateToMessage(Update update)
        {
            if (update.Message.Type == MessageType.LocationMessage) return new Message(UniveralBot.MessageType.Location,update.Message.Location,update.Message.Chat.Id.ToString());
            if (update.Message.Type == MessageType.TextMessage) return new Message(UniveralBot.MessageType.Text, update.Message.Text, update.Message.Chat.Id.ToString());
            if (update.Message.Type == MessageType.PhotoMessage) return new Message(UniveralBot.MessageType.Photo,update.Message.Photo, update.Message.Chat.Id.ToString());
            return new Message(UniveralBot.MessageType.Unknown, update.Message, update.Message.Chat.Id.ToString());
        }

    }

    
}