using AspNetPlayground.Domain;

namespace AspNetPlayground.Services.Senders;

public interface ISmsSender
{
    Task<bool> SendAsync(IMessage message, CancellationToken ct = default);
}