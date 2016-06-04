namespace UniveralBot
{
    public interface IMessageHandler
    {
        Message ProcessTheMessage(Message message);
    }
}