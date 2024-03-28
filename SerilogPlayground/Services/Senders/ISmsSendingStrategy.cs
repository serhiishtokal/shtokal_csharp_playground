using SerilogPlayground.Domain;
using SerilogPlayground.Services.Senders.ConcreteSmsSenders;

namespace SerilogPlayground.Services.Senders;

public interface ISmsSendingStrategy
{
    Task<bool> RunSmsSending(IMessage message, ConcreteSmsSenderType senderType, CancellationToken ct = default);
}