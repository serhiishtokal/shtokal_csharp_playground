using Serilog;
using Serilog.Context;

namespace SerilogPlayground.Services;

public class SampleService
{
    private readonly Serilog.ILogger _serilogLogger = Log.ForContext<SampleService>();
    private readonly ILogger<SampleService> _microsoftLogger;

    public SampleService(ILogger<SampleService> microsoftLogger)
    {
        _microsoftLogger = microsoftLogger;
    }
    
    public void DoSomething()
    {
        using (LogContext.PushProperty("SomeName", new {SomeProperty = "SomeValue"}))
        {
            _serilogLogger.Warning("SERILOG SampleService.DoSomething called");
            _serilogLogger.Warning("SERILOG SampleService.DoSomething called log 2");
        }
        
        using (_microsoftLogger.BeginScope(new { SomeProperty = "SomeValue" }))
        {
            _microsoftLogger.LogWarning("Microsoft SampleService.DoSomething called");
        }
    }
}