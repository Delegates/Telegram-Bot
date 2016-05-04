using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot;
using Bot.Parameters;

namespace TelegramBot
{
    class Start : ParametrizedCommand<EmptyParameters>
    {
        public override string Name => "start";
        public override string Description => "Стартовая команда";
        public override string Execute(EmptyParameters parameters)
        {
            return "wow such hello many friends";
        }
    }
}
