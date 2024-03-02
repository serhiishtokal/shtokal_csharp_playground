using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpPlayground.Interfaces;
using Dumpify;

namespace CSharpPlayground.Tests;

public class PLinq_T202402271306 : IAsyncTest
{
    public Task TestAsync()
    {
        var list = new List<int> { 1, 2, 3 };
        var k = list
            .AsParallel()
            .Where(x => x > 1)
            .WithMergeOptions(ParallelMergeOptions.AutoBuffered)
            .ToList();
        
        k.Dump();
        return Task.CompletedTask;
    }
}
