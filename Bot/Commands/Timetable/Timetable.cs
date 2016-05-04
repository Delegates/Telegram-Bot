using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Parameters;

namespace Bot.Commands
{
    public class Timetable : ParametrizedCommand<EmptyParameters>
    {
        #region Расписание
        internal static Dictionary<DayOfWeek, List<Lesson>> timetable = new Dictionary<DayOfWeek, List<Lesson>>
        {
            {
                DayOfWeek.Monday, new List<Lesson>
                {
                    new Lesson("Анлгийский", DateTime.Parse("12:50:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Физкультура", DateTime.Parse("18:00:00"), new TimeSpan(1, 0, 0))
                }
            },
            {
                DayOfWeek.Tuesday, new List<Lesson>
                {
                     new Lesson("Цирк", DateTime.Parse("9:00:00"), new TimeSpan(1, 30, 0)),
                     new Lesson("Дискретка", DateTime.Parse("10:40:00"), new TimeSpan(1, 30, 0)),
                     new Lesson("Дискретка", DateTime.Parse("12:50:00"), new TimeSpan(1, 30, 0))
                }
            },
            {
                DayOfWeek.Wednesday, 
                new List<Lesson>
                {
                    new Lesson("Сети", DateTime.Parse("9:00:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Английский", DateTime.Parse("12:50:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Сети", DateTime.Parse("14:30:00"), new TimeSpan(1, 30, 0))
                }
            },
            {
                DayOfWeek.Thursday, 
                new List<Lesson>
                {
                    new Lesson("Право", DateTime.Parse("10:40:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Дифуры", DateTime.Parse("12:50:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Дифуры", DateTime.Parse("14:30:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Физкультура", DateTime.Parse("18:00:00"), new TimeSpan(1, 30, 0))
                }
            },
            {
                DayOfWeek.Friday, 
                new List<Lesson>
                {
                    new Lesson("ООП", DateTime.Parse("9:20:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Комбинаторные алгоритмы", DateTime.Parse("10:30:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Теорвер", DateTime.Parse("12:50:00"), new TimeSpan(1, 30, 0)),
                    new Lesson("Комбинаторные алгоритмы", DateTime.Parse("14:30:00"), new TimeSpan(1, 30, 0))
                }
            }
        };
        #endregion

        public override string Name => "timetable";
        public override string Description => "Выводит расписание на сегодня";
        public override string Execute(EmptyParameters parameters)
        {
            var stringBuilder = new StringBuilder();
            foreach (var lesson in timetable[DateTime.Now.DayOfWeek])
                stringBuilder.AppendLine(lesson.ToString());
            return stringBuilder.ToString();
        }
    }
}
