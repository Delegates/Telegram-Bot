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
            var messageHandler = new Bot.MessageHandler();
            var commandList = new ICommand[]
            {
                new Help(messageHandler),
                new Start(),
                new Timetable(),
                new WhoIsStepan(),
                new Next()
            };
            messageHandler.AddCommands(commandList);
            var bot = new TelegramBot("182754992:AAH-OI66_6Xs4Zqo3KqI74TlGb6CLiXPqXI", messageHandler);
            bot.Start();
            Console.WriteLine("Doge приветствует вас");
            bot.MessageReceived += (update) => Console.WriteLine($"WoW new message : {DateTime.Now.ToString("T")} Type: {update.Type}");
            Console.ReadLine();
        }
    }
}
