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
            var messageHandler = new Bot.MessageHandler();
            messageHandler.AddCommands(new Bot.Commands.Help(messageHandler));
            Assert.AreEqual($"Доступные команды у Doge:{Environment.NewLine}help | Выводит список доступных команд{Environment.NewLine}", messageHandler.ExecuteCommand("Help"));
        }
    }
}