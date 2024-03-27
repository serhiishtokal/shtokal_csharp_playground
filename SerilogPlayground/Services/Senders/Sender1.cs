using Dumpify;
using SerilogPlayground.Domain;

namespace SerilogPlayground.Services.Senders;

public interface ISender
{
    Task<bool> Send(IMessage message);
}

public interface ISender1 : ISender;

public interface ISender2 : ISender;

public class Sender1: ISender1
{
    public Sender1()
    {
    }
    
    public Task<bool> Send(IMessage message)
    {
        "Sender1".Dump();
        message.Dump();
        return Task.FromResult(true);
    }
}

public class Sender2: ISender2
{
    public Sender2()
    {
    }
    public Task<bool> Send(IMessage message)
    {
        "Sender2".Dump();
        message.Dump();
        return Task.FromResult(true);
    }
}

public class Sender1Decorator1: ISender1
{
    private readonly ISender1 _decorated;
    
    public Sender1Decorator1(ISender1 decorated)
    {
        _decorated = decorated;
    }
    public Task<bool> Send(IMessage message)
    {
        throw new NotImplementedException();
    }
}

public class Sender2Decorator1: ISender2
{
    private readonly ISender2 _decorated;

    public Sender2Decorator1(ISender2 decorated)
    {
        _decorated = decorated;
    }

    public Task<bool> Send(IMessage message)
    {
        throw new NotImplementedException();
    }
}