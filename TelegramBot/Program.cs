using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot;
using Bot.Commands;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandBot = new Bot.Bot();
            var commandList = new ICommand[]
            {
                new Help(commandBot),
                new Start(),
                new Timetable(),
                new WhoIsStepan()
            };
            commandBot.AddCommands(commandList);
            var bot = new TelegramBot("182754992:AAH-OI66_6Xs4Zqo3KqI74TlGb6CLiXPqXI", commandBot);
            bot.Start();
            Console.WriteLine("Doge приветствует вас");
            bot.MessageReceived += () => Console.WriteLine("WoW new message : " + DateTime.Now);
            Console.ReadLine();
        }
    }
}
