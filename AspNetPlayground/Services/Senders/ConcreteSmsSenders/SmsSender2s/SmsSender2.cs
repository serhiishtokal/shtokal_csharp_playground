using AspNetPlayground.Domain;
using Dumpify;

namespace AspNetPlayground.Services.Senders.ConcreteSmsSenders.SmsSender2s;

public class SmsSender2: ISmsSender2
{
    public Task<bool> SendAsync(IMessage message, CancellationToken ct = default)
    {
        "Sender2".Dump();
        return Task.FromResult(true);
    }
}