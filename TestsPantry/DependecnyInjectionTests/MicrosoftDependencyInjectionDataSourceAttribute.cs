using Microsoft.Extensions.DependencyInjection;

namespace TestsPantry.DependecnyInjectionTests;

public class MicrosoftDependencyInjectionDataSourceAttribute : DependencyInjectionDataSourceAttribute<IServiceScope>
{
    private static readonly ServiceProvider RootProvider = CreateSharedServiceProvider();

    public override IServiceScope CreateScope(DataGeneratorMetadata dataGeneratorMetadata)
        => RootProvider.CreateScope();

    public override object? Create(IServiceScope scope, Type type)
        => scope.ServiceProvider.GetRequiredService(type);
    
    private static ServiceProvider CreateSharedServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddSingleton<SomeClass1>();
        services.AddScoped<SomeClass2>();
        services.AddTransient<SomeClass3>();

        return services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });
    }
}