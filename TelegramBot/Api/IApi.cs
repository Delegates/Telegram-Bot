using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.Api;


namespace TelegramBot
{
    public interface IApi
    {
        event EventHandler<UpdateEventArgs> UpdateReceived;
        Task<User> GetMe();
        void StartReceiving();
        [System.Obsolete("use SendUpdate(Update update)")]
        void SendTextMessage(long id, string text);
        [System.Obsolete("use SendUpdate(Update update)")]
        void SendPhoto(long id, FileToSend fileToSend);
        void SendUpdate(Api.Update update);
    }
}
