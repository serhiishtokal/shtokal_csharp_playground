using Dumpify;
using SerilogPlayground.Domain;

namespace SerilogPlayground.Services.Senders.ConcreteSmsSenders.SmsSender2s;

public class SmsSender2Decorator1: ISmsSender2
{
    private readonly ILogger<SmsSender2Decorator1> _logger;
    private readonly ISmsSender2 _decorated;

    public SmsSender2Decorator1(ISmsSender2 decorated, ILogger<SmsSender2Decorator1> logger)
    {
        _decorated = decorated;
        _logger = logger;
    }

    public Task<bool> SendAsync(IMessage message, CancellationToken ct = default)
    {
        "SmsSender2Decorator1".Dump();
        var isSent = _decorated.SendAsync(message, ct);
        return isSent;
    }
}