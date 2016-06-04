using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Parameters;
using Telegram.Bot.Types;

namespace Bot.Commands
{
    public class Time : ParametrizedCommand<EmptyParameters>
    {
        public override string Name => "time";
        public override string Description => "показывает сколько времени";
        public override string Execute(EmptyParameters parameters)
        {
            var time = DateTime.Now; 
            return time.ToString();
        }
    }
}
