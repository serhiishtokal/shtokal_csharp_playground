using Dumpify;
using SerilogPlayground.Domain;

namespace SerilogPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders;

public class CultureDynamicSmsSender: ISmsSender
{
    private readonly ISmsSendingStrategy _smsSendingStrategy;
    private readonly IConcreteSmsSenderTypeProvider _concreteSmsSenderTypeProvider;
    private readonly Culture _culture;

    public CultureDynamicSmsSender(Culture culture, ISmsSendingStrategy smsSendingStrategy, IConcreteSmsSenderTypeProvider concreteSmsSenderTypeProvider)
    {
        _culture = culture;
        _smsSendingStrategy = smsSendingStrategy;
        _concreteSmsSenderTypeProvider = concreteSmsSenderTypeProvider;
    }

    public async Task<bool> SendAsync(IMessage message, CancellationToken ct = default)
    {
        "CultureDynamicSmsSender".Dump();
        var concreteSmsSenderType = _concreteSmsSenderTypeProvider.GetSenderType(_culture);
        var isSent = await _smsSendingStrategy.RunSmsSending(message, concreteSmsSenderType, ct);
        return isSent;
    }
}