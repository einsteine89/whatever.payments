namespace Whatever.Payments.Infrastructure
{
    public interface IHandlMessage<T>
        where T : IMessage
    {
        void Handle(T message);
    }
}
