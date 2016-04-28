using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Commands
{
    class Lesson
    {
        public string Name { get; }
        public DateTime Start { get; }
        public TimeSpan Duratation { get; }
        public DateTime Ending => Start.Add(Duratation);

        public Lesson(string name, DateTime start, TimeSpan duratation)
        {
            Name = name;
            Start = start;
            Duratation = duratation;
        }
    }
}
