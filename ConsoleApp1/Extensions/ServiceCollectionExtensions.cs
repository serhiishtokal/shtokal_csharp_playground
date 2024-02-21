using ConsoleApp1.ArchivedTests;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddArchivedTests(this IServiceCollection services)
    {
        return services;
    } 
    
    public static IServiceCollection Add2024Tests(this IServiceCollection services)
    {
        services.AddScoped<ITest, EnumToString_T202402211647>();
        
        return services;
    }
}