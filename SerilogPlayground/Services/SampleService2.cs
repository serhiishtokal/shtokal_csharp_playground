namespace SerilogPlayground.Services;

public class SampleService2
{
    private readonly ILogger<SampleService2> _microsoftLogger;

    public SampleService2(ILogger<SampleService2> logger)
    {
        _microsoftLogger = logger;
    }

    public void TestScopeInsideScope()
    {
        using var scope = _microsoftLogger.BeginScope(new Dictionary<string, object>
        {
            ["InnerScopeKey"] = "InnerScopeValue"
        });
          
        _microsoftLogger.LogWarning("Microsoft SampleService2.TestScopeInsideScope called");
    }
}