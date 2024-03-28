using SerilogPlayground.Domain;

namespace SerilogPlayground.Services.Senders;

public interface ISmsSender
{
    Task<bool> SendAsync(IMessage message, CancellationToken ct = default);
}