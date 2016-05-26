using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot.Api
{
    class TelegramApi : IApi
    {
        public TelegramApi(string token)
        {
            api = new Telegram.Bot.Api(token);
            api.UpdateReceived += (sender, args) =>
            {
                UpdateReceived?.Invoke(sender, args);
            };
        }

        private readonly Telegram.Bot.Api api;
        public event EventHandler<UpdateEventArgs> UpdateReceived;
        public Task<User> GetMe()
        {
            return api.GetMe();
        }

        public void StartReceiving()
        {
            api.StartReceiving();
        }

        public void SendTextMessage(long id, string text)
        {
            api.SendTextMessage(id, text);
        }

        public void SendPhoto(long id, FileToSend fileToSend)
        {
            api.SendPhoto(id, fileToSend);
        }

        public void SendUpdate(Update update)
        {
            throw new NotImplementedException();

        }
    }
}
