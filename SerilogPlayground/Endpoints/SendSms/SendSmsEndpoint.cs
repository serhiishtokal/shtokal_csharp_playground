using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using SerilogPlayground.Domain;
using SerilogPlayground.Endpoints.GetTraceIdentifier;
using SerilogPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders.Factories;

namespace SerilogPlayground.Endpoints.SendSms;

public class SendSmsRequest
{
    [QueryParam]
    [Required]
    public string Culture { get; set; } = null!;
}

// decorator pattern + strategy
public class SendSmsEndpoint : Endpoint<SendSmsRequest>
{
    private readonly ILogger<GetTraceIdentifierEndpoint> _logger;
    private readonly ICultureDynamicSmsSenderFactory _cultureDynamicSmsSenderFactory;

    public SendSmsEndpoint(
        ILogger<GetTraceIdentifierEndpoint> logger,ICultureDynamicSmsSenderFactory cultureDynamicSmsSenderFactory)
    {
        _logger = logger;
        _cultureDynamicSmsSenderFactory = cultureDynamicSmsSenderFactory;
    }

    public override void Configure()
    {
        Get($"/{nameof(SendSmsEndpoint)}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SendSmsRequest request, CancellationToken ct)
    {
       var culture = Culture.Create(request.Culture); 
       var smsSender = _cultureDynamicSmsSenderFactory.GetSmsSender(culture);
       var message = new Message("Hello!", "PhoneNumber");
       var isSent = await smsSender.SendAsync(message, ct);
       await SendAsync(isSent, cancellation: ct);
    }
}