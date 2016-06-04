using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot;
using Bot.Commands;
using Bot.Parameters;

namespace Bot.Commands
{
    public class Next : ParametrizedCommand<EmptyParameters>
    {
        public override string Name => "next";
        public override string Description => "показывает ближайшую пару";
        public override string Execute(EmptyParameters parameters)
        {
            var nextLesson = FindNextLesson(DateTime.Now);
            return $"{nextLesson} (До пары: {string.Format("{0:%d} дней {0:%h} часов {0:%m} минут", nextLesson.Start - DateTime.Now)})";
        }

        private static Lesson FindNextLesson(DateTime date)
        {
            while (true)
            {
                var nextLesson = Timetable.timetable[date.DayOfWeek]
            .FirstOrDefault(l => l.Ending.AddDays(date.Day - DateTime.Now.Day) > DateTime.Now);
                if (nextLesson != null)
                {
                    return new Lesson(nextLesson.Name, nextLesson.Start.AddDays(date.Day - DateTime.Now.Day), nextLesson.Duratation);
                }
                date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).AddDays(1);
            }
        }
    }
}
