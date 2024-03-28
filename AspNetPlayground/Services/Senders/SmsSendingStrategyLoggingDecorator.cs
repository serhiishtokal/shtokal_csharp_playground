using AspNetPlayground.Domain;
using AspNetPlayground.Services.Senders.ConcreteSmsSenders;

namespace AspNetPlayground.Services.Senders;

public class SmsSendingStrategyLoggingDecorator: ISmsSendingStrategy
{
    private readonly ISmsSendingStrategy _decorated;
    private readonly ILogger<SmsSendingStrategyLoggingDecorator> _logger;
    
    public SmsSendingStrategyLoggingDecorator(ISmsSendingStrategy decorated, ILogger<SmsSendingStrategyLoggingDecorator> logger)
    {
        _decorated = decorated;
        _logger = logger;
    }

    public async Task<bool> RunSmsSending(IMessage message, ConcreteSmsSenderType senderType, CancellationToken ct = default)
    {
        using var loggingScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["SenderType"] = senderType,
            ["Message"] = message,
            ["Action"] = "SmsSending"
        });
        
        _logger.LogInformation("Sending SMS");
        
        var isSent = await _decorated.RunSmsSending(message, senderType, ct);
        
        _logger.LogInformation("SMS sent successfully");
        return isSent;
    }
}