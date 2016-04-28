using System;
using NUnit.Framework;

namespace BotTest
{
    [TestFixture]
    public class NUnitTest
    {
        [Test]
        public void TestHelpCommand()
        {
            var bot = new Bot.Bot();
            bot.AddCommands(new Bot.Commands.Help(bot));
            Assert.AreEqual($"Доступные команды у бота:{Environment.NewLine}Help | Выводит список доступных команд{Environment.NewLine}", bot.ExecuteCommand("Help"));
        }
    }
}