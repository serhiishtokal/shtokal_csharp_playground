using Serilog;
using ILogger = Serilog.ILogger;

namespace SerilogPlayground.Services;

public class SampleService
{
    private readonly ILogger _logger = Log.ForContext<SampleService>();

    public SampleService()
    {
        var k = Log.ForContext<SampleService>();
    }
    
    public void DoSomething()
    {
        _logger.Information("SampleService.DoSomething called");
    }
}