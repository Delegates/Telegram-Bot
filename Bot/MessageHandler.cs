using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    public class MessageHandler
    {
        private readonly List<ICommand> commandList;
        private readonly Dictionary<string, ICommand> nameToCommand = new Dictionary<string, ICommand>(); 

        public MessageHandler()
        {
            commandList = new List<ICommand>();
        }

        public MessageHandler(params ICommand[] commands)
        {
            AddCommands(commands);
        }

        public MessageHandler AddCommands(params ICommand[] commands)
        {
            foreach (var command in commands)
            {
                commandList.Add(command);
                nameToCommand.Add(command.Name, command);
            }
            return this;
        }

        public IReadOnlyList<ICommand> CommandList => commandList.AsReadOnly(); 

        public string ExecuteCommand(string command, params string[] args)
        {
            var cmd = command.ToLower();
            if (!nameToCommand.ContainsKey(cmd)) return "WoW so unusual much unknown letters";
            return nameToCommand[cmd].Execute(args);
        }

    }
}
