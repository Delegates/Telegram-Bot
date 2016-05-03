using Bot;

namespace TelegramBot
{
    public class TelegramBot
    {
        private string Token { get; }
        public string CommandPrefix { get; set; }
        public Bot.Bot Bot { get; }
    }
}
