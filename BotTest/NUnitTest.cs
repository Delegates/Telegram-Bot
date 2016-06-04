using System;
using NUnit.Framework;
using TelegramBot.Handler;

namespace BotTest
{
    [TestFixture]
    public class NUnitTest
    {
        [Test]
        public void TestHelpCommand()
        {
            var messageHandler = new TextHandler();
            messageHandler.AddCommands(new Bot.Commands.Help(messageHandler));
            Assert.AreEqual($"Доступные команды у Doge:{Environment.NewLine}help | Выводит список доступных команд{Environment.NewLine}", messageHandler.ExecuteCommand("Help"));
        }
    }
}