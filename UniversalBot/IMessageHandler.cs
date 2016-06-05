namespace UniveralBot
{
    public interface IMessageHandler<TMessage>
    {
        TMessage ProcessTheMessage(TMessage message);
    }
}