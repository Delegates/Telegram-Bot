using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Parameters;

namespace Bot.Commands
{
    class Timetable : ParametrizedCommand<EmptyParameters>
    {
        private static Dictionary<DayOfWeek, List<Lesson>> timetable = new Dictionary<DayOfWeek, List<Lesson>>
        {
            {
                DayOfWeek.Monday, new List<Lesson>
                {
                    new Lesson("Анлгийский", DateTime.Parse("12:50:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Физкультура", DateTime.Parse("18:00:00"), new TimeSpan(1, 0, 0))
                }
            } //,
            // TODO: Доделать
        };
        public override string Name => "Timetable";
        public override string Description => "Выводит расписание на сегодня";
        public override string Execute(EmptyParameters parameters)
        {
            
            throw new NotImplementedException();
        }
    }
}
