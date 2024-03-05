﻿using Serilog;
using Serilog.Context;

namespace SerilogPlayground.Services;

public class SampleService
{
    private readonly Serilog.ILogger _serilogLogger = Log.ForContext<SampleService>();
    private readonly ILogger<SampleService> _microsoftLogger;
    private readonly SampleService2 _sampleService2;

    public SampleService(ILogger<SampleService> microsoftLogger,
        SampleService2 sampleService2)
    {
        _microsoftLogger = microsoftLogger;
        _sampleService2 = sampleService2;
    }
    
    public void DoSomething()
    {
        using (LogContext.PushProperty("SomeName", new {SomeProperty = "SomeValue"}))
        {
            _serilogLogger.Warning("SERILOG 1 SampleService.DoSomething called");
        }
        
        using (_microsoftLogger.BeginScope(new Dictionary<string, object>
               {
                   ["SomeName"] = new {SomeProperty = "SomeValue"}
               }))
        {
            _microsoftLogger.LogWarning("Microsoft 1 SampleService.DoSomething called");
        }
        
        // using (_microsoftLogger.BeginScope(new { SomeProperty = "SomeValue" }))
        // {
        //     using (_microsoftLogger.BeginScope(new { SomeProperty2 = "SomeValue" }) )
        //     {
        //         _microsoftLogger.LogWarning("Microsoft SampleService.DoSomething inner scope called"); 
        //     }
        //     
        //     _microsoftLogger.LogWarning("Microsoft SampleService.DoSomething outer scope called");
        // }
    }

    public void TestScopeInsideScope()
    {
          using var scope = _microsoftLogger.BeginScope(new Dictionary<string, object>
          {
              ["OuterScopeKey"] = "OuterScopeValue"
          });
          _microsoftLogger.LogWarning("Microsoft SampleService.TestScopeInsideScope called");
          _sampleService2.TestScopeInsideScope();
    }
}