using Dumpify;
using FastEndpoints;
using SerilogPlayground.Endpoints.GetTraceIdentifier;
using SerilogPlayground.Services.Senders;

namespace SerilogPlayground.Endpoints.DecorateTests;

public class DecorateTestEndpoint : EndpointWithoutRequest
{
    private readonly ILogger<GetTraceIdentifierEndpoint> _logger;
    private readonly IEnumerable<ISender> _senders;

    public DecorateTestEndpoint(
        ILogger<GetTraceIdentifierEndpoint> logger, IEnumerable<ISender> senders)
    {
        _logger = logger;
        _senders = senders;
    }

    public override void Configure()
    {
        Get("/DecorateTestEndpoint");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        _senders.Dump();
        return Task.CompletedTask;
    }
}