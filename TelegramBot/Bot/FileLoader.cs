using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
    class FileLoader
    {
        public static Telegram.Bot.Api LoadApi(string fileName)
        {
            var token = File.ReadAllLines(fileName)[0].Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)[1];
            return new Telegram.Bot.Api(token);
        }

        //public static Bot.Bot LoadCommands(string fileName)
        //{
            
        //}
    }
}
