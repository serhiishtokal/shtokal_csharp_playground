using SerilogPlayground.Services.Senders.ConcreteSmsSenders.SmsSender1s;
using SerilogPlayground.Services.Senders.ConcreteSmsSenders.SmsSender2s;

namespace SerilogPlayground.Services.Senders.ConcreteSmsSenders;

public class ConcreteSmsSenderFactory: IConcreteSmsSenderFactory
{
    private readonly ISmsSender1 _smsSender1;
    private readonly ISmsSender2 _smsSender2;

    public ConcreteSmsSenderFactory(ISmsSender1 smsSender1, ISmsSender2 smsSender2)
    {
        _smsSender1 = smsSender1;
        _smsSender2 = smsSender2;
    }

    public IConcreteSmsSender GetSmsSender(ConcreteSmsSenderType senderType)
    {
        return senderType switch
        {
            ConcreteSmsSenderType.SmsSender1 => _smsSender1,
            ConcreteSmsSenderType.SmsSender2 => _smsSender2,
            _ => throw new ArgumentOutOfRangeException(nameof(senderType), senderType, null)
        };
    }
}