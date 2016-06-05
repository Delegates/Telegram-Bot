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
using UniveralBot;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot<Message> bot = null;
                     
            var lazy = new Lazy<TextHandler>(() => new TextHandler(bot.me));
            bot = new Bot<Message>(new MessageHandler(lazy,new PhotoHandler(), new LocationHandler()),new TelegramApi("182754992:AAH-OI66_6Xs4Zqo3KqI74TlGb6CLiXPqXI"));
            var commandList = new ICommand[]
            {
                new Help(lazy),
                new Start(),
                new Timetable(),
                new Time(),
                new Next()
            };

            lazy.Value.AddCommands(commandList);
       
            bot.Start();
            Console.WriteLine("Doge приветствует вас");
            bot.MessageReceived += (update) => Console.WriteLine($"WoW new message : {DateTime.Now.ToString("T")} Type: {update.Type} Текст{update.Data}");
            Console.ReadLine();
        }
    }
}
