using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Telegram.Bot.Api("123");
            bot.GetMe()
        }
    }
}
