using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bot;
using Bot.Commands;
using Telegram.Bot;
using TelegramBot.Api;
using TelegramBot.Handler;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var textMessageHandler = new TextHandler();
            var commandList = new ICommand[]
            {
                new Help(textMessageHandler),
                new Start(),
                new Timetable(),
                new Time(),
                new Next()
            };

            textMessageHandler.AddCommands(commandList);
            var locationMessageHandler = new LocationHandler();
            var photoMessageHandler = new PhotoHandler();
            var bot = new TelegramBot(textMessageHandler,photoMessageHandler, locationMessageHandler, new TelegramApi("182754992:AAH-OI66_6Xs4Zqo3KqI74TlGb6CLiXPqXI"));
            bot.Start();
            Console.WriteLine("Doge приветствует вас");
            bot.MessageReceived += (update) => Console.WriteLine($"WoW new message : {DateTime.Now.ToString("T")} Type: {update.Type} Текст{update.Message.Text}");
            Console.ReadLine();
        }
    }
}
