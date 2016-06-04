using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using UniveralBot;
using Message = UniveralBot.Message;
using User = Telegram.Bot.Types.User;

namespace TelegramBot.Api
{
    class TelegramApi : IApi
    {
        public TelegramApi(string token)
        {
            api = new Telegram.Bot.Api(token);
            api.UpdateReceived += (sender, args) =>
            {
                MessageReceived?.Invoke(sender, args);
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
            api.
        }


    }
}
