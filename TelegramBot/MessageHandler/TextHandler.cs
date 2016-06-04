using System;
using System.Collections.Generic;
using System.Linq;
using Bot;
using UniveralBot;


namespace TelegramBot.Handler
{
    public class TextHandler 
    {
        private string commandPrefix;

        private UniveralBot.Bot bot;
        private readonly List<ICommand> commandList;
        private readonly Dictionary<string, ICommand> nameToCommand = new Dictionary<string, ICommand>();


        public TextHandler(UniveralBot.Bot bot,string prefix = "/", params ICommand[] commands)
        {
            commandPrefix = prefix;
            commandList = new List<ICommand>();
            AddCommands(commands);
            this.bot = bot;
        }



        public TextHandler AddCommands(params ICommand[] commands)
        {
            foreach (var command in commands)
            {
                commandList.Add(command);
                nameToCommand.Add(command.Name, command);
            }
            return this;
        }

        public IReadOnlyList<ICommand> CommandList => commandList.AsReadOnly();


        public UniveralBot.Message ProcessTheMessage(string message)
        {
            if (message == null || !message.StartsWith(commandPrefix) || message.Length==1) return UniveralBot.Message.EmptyMessage;
            var text = message;
            text = text.EndsWith($"@{bot.me.UserName}") ? text.Substring(commandPrefix.Length, text.Length - 1 - bot.me.UserName.Length - 1) : text.Substring(commandPrefix.Length);
            var command = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Message(MessageType.Text,ExecuteCommand(command[0], command.Skip(1).ToArray()));
        }

        public string ExecuteCommand(string command, params string[] args)
        {
            var cmd = command.ToLower();
            if (!nameToCommand.ContainsKey(cmd)) return "WoW so unusual much unknown letters";
            return nameToCommand[cmd].Execute(args);
        }
    }
}