using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using Telegram.Bot;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace TelegramBot.Handler
{
    public class LocationMessageHandler : IMessageHandler
    {
        public void ProcessTheMessage(Message message, IApi api, User user)
        {
            api.SendTextMessage(message.Chat.Id, "wow such map much location");
            api.SendPhoto(message.Chat.Id, new FileToSend("123", new FileStream("1.jpg", FileMode.Open)));
        }
    }
}