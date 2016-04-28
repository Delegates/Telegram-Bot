using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Parameters;


namespace Bot.Commands
{
    public class Help : ParametrizedCommand<EmptyParameters>
    {
        private readonly Bot bot;

        public Help(Bot bot)
        {
            this.bot = bot;
        }

        public override string Name => "Help";
        public override string Description => "Выводит список доступных команд";

        public override string Execute(EmptyParameters parameters)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Доступные команды у бота:");
            foreach (var command in bot.CommandList)
            {
                stringBuilder.Append(command.Name);
                stringBuilder.Append(" | ");
                stringBuilder.AppendLine(command.Description);
            }
            return stringBuilder.ToString();
        }
    }
}
