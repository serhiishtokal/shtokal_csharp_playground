using AspNetPlayground.Domain;
using Dumpify;

namespace AspNetPlayground.Services.Senders.ConcreteSmsSenders.SmsSender1s;

public class SmsSender1: ISmsSender1
{
    public Task<bool> SendAsync(IMessage message, CancellationToken ct = default)
    {
        "Sender1".Dump();
        message.Dump();
        return Task.FromResult(true);
    }
}