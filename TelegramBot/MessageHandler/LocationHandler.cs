using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using Telegram.Bot;
using Telegram.Bot.Types;
using UniveralBot;


namespace TelegramBot.Handler
{
    public class LocationHandler 
    {
        public UniveralBot.Message ProcessTheMessage(Location message)
        {
         //   api.SendTextMessage(message.Chat.Id, "wow such map much location");
        
            return new UniveralBot.Message(UniveralBot.MessageType.Text, "wow such map much location");
        }
    }
}