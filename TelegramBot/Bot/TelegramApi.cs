using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using UniveralBot;
using Message = UniveralBot.Message;
using MessageType = UniveralBot.MessageType;
using User = Telegram.Bot.Types.User;

namespace TelegramBot.Api
{
    class TelegramApi : IApi<Message>
    {
        public TelegramApi(string token)
        {
            api = new Telegram.Bot.Api(token);
            api.UpdateReceived += (sender, updateEventArgs) =>
            {
                MessageReceived?.Invoke(sender, Converter.UpdateToMessage(updateEventArgs.Update));
            };

            Me = new UniveralBot.User(api.GetMe().Result.Username);
        }

        private readonly Telegram.Bot.Api api;


        public event EventHandler<Message> MessageReceived;

        public UniveralBot.User Me { get; }

        public void StartReceiving()
        {
            api.StartReceiving();
        }


        public void SendMessage(Message message)
        {            
            if (message.Type == MessageType.Location)
            {
                var location = (Location)message.Data;
                api.SendLocation(message.ChatId, location.Latitude, location.Longitude);
            }
            if (message.Type == MessageType.Photo)
            {
                var photo = (FileToSend)message.Data;
                api.SendPhoto(message.ChatId, photo);
            }
            if (message.Type == MessageType.Text)
            {
                var text = (string)message.Data;
                api.SendTextMessage(message.ChatId, text);
            }
        }

       
    }
}
