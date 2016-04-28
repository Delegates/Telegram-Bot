using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    public class Bot
    {
        private readonly List<ICommand> commandList;
        private readonly Dictionary<string, ICommand> nameToCommand = new Dictionary<string, ICommand>(); 

        public Bot()
        {
            commandList = new List<ICommand>();
        }

        public Bot(params ICommand[] commands)
        {
            AddCommands(commands);
        }

        public Bot AddCommands(params ICommand[] commands)
        {
            foreach (var command in commands)
            {
                commandList.Add(command);
                nameToCommand.Add(command.Name, command);
            }
            return this;
        }

        public IReadOnlyList<ICommand> CommandList => commandList.AsReadOnly(); 

        public string ExecuteCommand(string command, params string[] args) => nameToCommand[command].Execute(args);

    }
}
