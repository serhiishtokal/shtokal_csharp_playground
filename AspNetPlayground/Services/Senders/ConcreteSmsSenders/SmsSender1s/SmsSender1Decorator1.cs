using AspNetPlayground.Domain;
using Dumpify;

namespace AspNetPlayground.Services.Senders.ConcreteSmsSenders.SmsSender1s;

public class SmsSender1Decorator1: ISmsSender1
{
    private readonly ILogger<SmsSender1Decorator1> _logger;
    private readonly ISmsSender1 _decorated;
    
    public SmsSender1Decorator1(ISmsSender1 decorated, ILogger<SmsSender1Decorator1> logger)
    {
        _decorated = decorated;
        _logger = logger;
    }
    public async Task<bool> SendAsync(IMessage message, CancellationToken ct = default)
    {
        "SmsSender1Decorator1".Dump();
        var isSent = await _decorated.SendAsync(message, ct);
        return isSent;
    }
}