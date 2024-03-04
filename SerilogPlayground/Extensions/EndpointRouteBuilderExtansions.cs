using SerilogPlayground.Endpoints;

namespace SerilogPlayground.Extensions;

public static class EndpointRouteBuilderExtansions
{
    //register endpoints
    public static void MapEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        GetWeatherEndpoint.Configure(endpointRouteBuilder);
    }
}