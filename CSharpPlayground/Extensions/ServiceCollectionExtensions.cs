using System.Linq;
using CSharpPlayground.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpPlayground.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllAsyncTests(this IServiceCollection services)
    {
        var asyncTestImplementationTypes = typeof(Program).Assembly.GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false })
            .Where(t => typeof(IAsyncTest).IsAssignableFrom(t))
            .OrderBy(t => t.Name.Split("_T").Last())
            .ToList();

        foreach (var asyncTestImplementationType in asyncTestImplementationTypes)
        {
            services.AddScoped(typeof(IAsyncTest), asyncTestImplementationType);
        }

        return services;
    }
}