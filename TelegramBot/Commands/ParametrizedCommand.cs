using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Parameters;

namespace Bot
{
    public abstract class ParametrizedCommand<TParameters> : ICommand
        where TParameters : IParameters, new()
    {
        readonly IParametersHandler<TParameters> handler = new ParametersHandler<TParameters>();

        public abstract string Name { get; }
        public abstract string Description { get; }

        public string Execute(string[] args)
        {
            return Execute(handler.CreateParameters(args));
        }

        public abstract string Execute(TParameters parameters);
    }
}
