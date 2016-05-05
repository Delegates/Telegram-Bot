using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Parameters;

namespace Bot.Commands
{
    public class WhoIsStepan : ParametrizedCommand<EmptyParameters>
    {
        public override string Name => "скажи мне кто стипан";
        public override string Description => "Говорит кто стипан";
        public override string Execute(EmptyParameters parameters)
        {
            return "Стипан пёс";
        }
    }
}
