using SerilogPlayground.Domain;
using SerilogPlayground.Services.Senders.ConcreteSmsSenders;

namespace SerilogPlayground.Services.Senders;

public class SmsSendingStrategy: ISmsSendingStrategy
{
    private readonly IConcreteSmsSenderFactory _concreteSmsSenderFactory;

    public SmsSendingStrategy(IConcreteSmsSenderFactory concreteSmsSenderFactory)
    {
        _concreteSmsSenderFactory = concreteSmsSenderFactory;
    }

    public async Task<bool> RunSmsSending(IMessage message, ConcreteSmsSenderType senderType, CancellationToken ct = default)
    {
        var concreteSmsSender = _concreteSmsSenderFactory.GetSmsSender(senderType);
        var isSent = await concreteSmsSender.SendAsync(message, ct);
        return isSent;
    }
}