using System.Diagnostics;
using FastEndpoints;

namespace SerilogPlayground.Endpoints.GetTraceIdentifier;

public record GetTraceIdentifierResponse(string TraceIdentifier, string? ActivityId);

public class GetTraceIdentifierEndpoint : EndpointWithoutRequest<GetTraceIdentifierResponse>
{
    private readonly ILogger<GetTraceIdentifierEndpoint> _logger;

    public GetTraceIdentifierEndpoint(ILogger<GetTraceIdentifierEndpoint> logger)
    {
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/GetTraceIdentifierRequest");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var traceIdentifier = HttpContext.TraceIdentifier;
        var activityId = Activity.Current?.Id;
        
        using var loggingScope = _logger.BeginScope(new Dictionary<string, object?>
        {
            ["TraceIdentifier2"] = traceIdentifier,
            ["ActivityId2"] = activityId
        });
 
        using var loggingScope2 = _logger.BeginScope(new Dictionary<string, object?>
        {
            ["TraceIdentifier2"] = traceIdentifier,
            ["ActivityId2"] = activityId
        });
        
        using var loggingScope3 = _logger.BeginScope(new {TraceIdentifier2 = "value2"});
        
        using var loggingScope4 = _logger.BeginScope("scope4");
        using var loggingScope5 = _logger.BeginScope("scope5");
        
        _logger.LogInformation("logging message {TraceIdentifier2}", "rewrite parameter");
        
        await SendAsync(new GetTraceIdentifierResponse(traceIdentifier, activityId), cancellation: ct);
    }
}