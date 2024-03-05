using SerilogPlayground.Services;

namespace SerilogPlayground.Endpoints;

public class InnerScopeTestEndpoint
{
    public static void Configure(IEndpointRouteBuilder endpointRouteBuilder) =>
        endpointRouteBuilder
            .MapGet("/InnerScopeTestEndpoint", Handle)
            .WithName("InnerScopeTestEndpoint")
            .WithOpenApi();
    
    private static void Handle(SampleService sampleService)
    {
        sampleService.TestScopeInsideScope();
    }
}