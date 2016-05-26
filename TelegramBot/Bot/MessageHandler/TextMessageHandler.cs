using System;
using System.Collections.Generic;
using System.Linq;
using Bot;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Handler
{
    public class TextMessageHandler :  IMessageHandler
    {
        private string commandPrefix;


        private readonly List<ICommand> commandList;
        private readonly Dictionary<string, ICommand> nameToCommand = new Dictionary<string, ICommand>();


        public TextMessageHandler(string prefix = "/")
        {
            commandPrefix = prefix;
            commandList = new List<ICommand>();
        }

        public TextMessageHandler(params ICommand[] commands)
        {
            commandList = new List<ICommand>();
            AddCommands(commands);
        }

        public TextMessageHandler AddCommands(params ICommand[] commands)
        {
            foreach (var command in commands)
            {
                commandList.Add(command);
                nameToCommand.Add(command.Name, command);
            }
            return this;
        }

        public IReadOnlyList<ICommand> CommandList => commandList.AsReadOnly();


        public void ProcessTheMessage(Message message, IApi api, User user)
        {
            if (message.Text == null || !message.Text.StartsWith(commandPrefix) || message.Text.Length==1) return;
            var text = message.Text;
            text = text.EndsWith($"@{user.Username}") ? text.Substring(commandPrefix.Length, text.Length - 1 - user.Username.Length - 1) : text.Substring(commandPrefix.Length);
            var command = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            api.SendTextMessage(message.Chat.Id, ExecuteCommand(command[0], command.Skip(1).ToArray()));
        }

        public string ExecuteCommand(string command, params string[] args)
        {
            var cmd = command.ToLower();
            if (!nameToCommand.ContainsKey(cmd)) return "WoW so unusual much unknown letters";
            return nameToCommand[cmd].Execute(args);
        }
    }
}