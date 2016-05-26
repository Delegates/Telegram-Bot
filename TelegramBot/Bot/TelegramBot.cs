using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Handler;

namespace TelegramBot
{
    public class TelegramBot
    {
        private string Token { get; }
        public string CommandPrefix { get; set; }

        private readonly IApi api;
        public event Action<Update> MessageReceived;
        private User me;


        public TelegramBot(TextMessageHandler textMessageHandler, PhotoMessageHandler photoMessageHandler,
            LocationMessageHandler locationMessageHandler, IApi api)
        {

            this.api = api;
            me = api.GetMe().Result;
            var updateHandler = new UpdateHandler(textMessageHandler, photoMessageHandler, locationMessageHandler, api,
                me);
            //api.MessageReceived += (sender, args) => MessageHandler(args.Message);
            api.UpdateReceived += (sender, args) => MessageReceived?.Invoke(args.Update);

            api.UpdateReceived += (sender, args) => updateHandler.ProcessingUpdate(args.Update);
            //new Thread(async () => me = await api.GetMe()).Start();
        }

        //private async void CheckMessage()
        //{
        //    while (true)
        //    {
        //        var updates = await api.GetUpdates();
        //        foreach (var update in updates)
        //        {
        //            MessageReceived(update);
        //        }

        //    }
        //}

        //private void MessageHandler(Message message)
        //{
        //    if (message.Text == null || !message.Text.StartsWith(CommandPrefix)) return;
        //    var text = message.Text;
        //    text = text.EndsWith($"@{me.Username}") ? text.Substring(CommandPrefix.Length, text.Length - 1 - me.Username.Length - 1) : text.Substring(CommandPrefix.Length);
        //    var command =text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        //    api.SendTextMessage(message.Chat.Id, messageHandler.ExecuteCommand(command[0], command.Skip(1).ToArray()));
        //}

        public void Start()
        {
            api.StartReceiving();
        }
    }
}