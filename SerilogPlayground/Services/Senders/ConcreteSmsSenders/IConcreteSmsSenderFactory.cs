namespace SerilogPlayground.Services.Senders.ConcreteSmsSenders;

public interface IConcreteSmsSenderFactory
{
    IConcreteSmsSender GetSmsSender(ConcreteSmsSenderType senderType);
}