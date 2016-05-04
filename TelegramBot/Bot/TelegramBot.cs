using System;
using System.Linq;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    public class TelegramBot
    {
        private string Token { get; }
        public string CommandPrefix { get; set; }
        private readonly Bot.Bot commandBot;
        private readonly Api api;
        public event Action MessageReceived;

        public TelegramBot(string token, Bot.Bot commandBot, string commandPrefix = @"/")
        {
            Token = token;
            this.commandBot = commandBot;
            api = new Api(token);
            api.MessageReceived += (sender, args) =>
            {
                MessageHandler(args.Message);
                MessageReceived?.Invoke();
            };
            CommandPrefix = commandPrefix;
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
            if (!message.Text.StartsWith(CommandPrefix)) return;
            var command = message.Text.Remove(0, CommandPrefix.Length)
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            api.SendTextMessage(message.Chat.Id, commandBot.ExecuteCommand(command[0], command.Skip(1).ToArray()));
        }

        public void Start()
        {
            api.StartReceiving();
        }
    }
}
