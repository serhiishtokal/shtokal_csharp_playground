using AspNetPlayground.Domain;
using AspNetPlayground.Services.Senders.ConcreteSmsSenders;

namespace AspNetPlayground.Services.Senders;

public interface ISmsSendingStrategy
{
    Task<bool> RunSmsSending(IMessage message, ConcreteSmsSenderType senderType, CancellationToken ct = default);
}