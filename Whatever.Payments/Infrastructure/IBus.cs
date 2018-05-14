namespace Whatever.Payments.Infrastructure
{
    public interface IBus
    {
        void Send(IMessage message);
        void RegisterHandlerFor<T>(IHandlMessage<T> handler) where T : IMessage;
    }
}
