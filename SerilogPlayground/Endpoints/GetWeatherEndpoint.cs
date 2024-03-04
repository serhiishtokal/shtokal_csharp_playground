using SerilogPlayground.Services;

namespace SerilogPlayground.Endpoints;

public class GetWeatherEndpoint
{
    public static void Configure(IEndpointRouteBuilder endpointRouteBuilder) =>
    endpointRouteBuilder
        .MapGet("/weatherforecast", Handle)
        .WithName("GetWeatherForecast")
        .WithOpenApi();

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    private static WeatherForecast[] Handle(SampleService sampleService)
    {
        sampleService.DoSomething();
        
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
            .ToArray();
        return forecast;
    }
    
    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}