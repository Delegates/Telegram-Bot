using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    public class TelegramBot
    {
        private string Token { get; }
        public string CommandPrefix { get; set; }
        private readonly Bot.MessageHandler messageHandler;
        private readonly Api api;
        public event Action<Update> MessageReceived;
        private User me;

        public TelegramBot(string token, Bot.MessageHandler messageHandler, string commandPrefix = @"/")
        {
            Token = token;
            this.messageHandler = messageHandler;
            api = new Api(token);
            api.MessageReceived += (sender, args) => MessageHandler(args.Message);
            api.UpdateReceived += (sender, args) => MessageReceived?.Invoke(args.Update);
            CommandPrefix = commandPrefix;
            new Thread(async () => me = await api.GetMe()).Start();
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

        private void MessageHandler(Message message)
        {
            if (message.Text == null || !message.Text.StartsWith(CommandPrefix)) return;
            var text = message.Text;
            text = text.EndsWith($"@{me.Username}") ? text.Substring(CommandPrefix.Length, text.Length - 1 - me.Username.Length - 1) : text.Substring(CommandPrefix.Length);
            var command =text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            api.SendTextMessage(message.Chat.Id, messageHandler.ExecuteCommand(command[0], command.Skip(1).ToArray()));
        }

        public void Start()
        {
            api.StartReceiving();
        }
    }
}
