using System;
using System.Linq;
using System.Runtime.InteropServices;
using Bot;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Handler;

namespace TelegramBot
{
    public class UpdateHandler
    {
        private TextMessageHandler textMessageHandler;
        private PhotoMessageHandler photoMessageHandler;
        private LocationMessageHandler locationMessageHandler;

        private IApi api;
        private User me;

        public UpdateHandler(TextMessageHandler textMessageHandler, PhotoMessageHandler photoMessageHandler, LocationMessageHandler locationMessageHandler, IApi api, User me)
        {
            this.textMessageHandler = textMessageHandler;
            this.photoMessageHandler = photoMessageHandler;
            this.locationMessageHandler = locationMessageHandler;
            this.api = api;
            this.me = me;
        }


        public void ProcessingUpdate(Update update)
        {
            //var update1 = new Update {Message = new Message()};

            if (update.Type == UpdateType.MessageUpdate)
            {
                var message = update.Message;
                if (message.Type == MessageType.TextMessage)
                {
                    textMessageHandler.ProcessTheMessage(message,api,me); 
                }
                if (message.Type == MessageType.LocationMessage)
                {
                    locationMessageHandler.ProcessTheMessage(message, api, me);
                }
                if (message.Type == MessageType.ContactMessage)
                {
                    //ничего не делать                 
                }
                if (message.Type == MessageType.PhotoMessage)
                {
                    photoMessageHandler.ProcessTheMessage(message,api,me);
                }
            }
        }
    }
}