using SerilogPlayground.Services.Senders;
using SerilogPlayground.Services.Senders.ConcreteSmsSenders;
using SerilogPlayground.Services.Senders.ConcreteSmsSenders.SmsSender1s;
using SerilogPlayground.Services.Senders.ConcreteSmsSenders.SmsSender2s;
using SerilogPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders;
using SerilogPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders.Factories;

namespace SerilogPlayground.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSmsSenders(this IServiceCollection services)
    {
        services.AddSingleton<ISmsSender1, SmsSender1>();
        services.Decorate<ISmsSender1, SmsSender1Decorator1>();

        services.AddSingleton<ISmsSender2, SmsSender2>();
        services.Decorate<ISmsSender2, SmsSender2Decorator1>();

        services.AddSingleton<IConcreteSmsSenderFactory, ConcreteSmsSenderFactory>();

        services.AddSingleton<ISmsSendingStrategy, SmsSendingStrategy>();
        services.Decorate<ISmsSendingStrategy, SmsSendingStrategyLoggingDecorator>();

        services.AddSingleton<ICultureDynamicSmsSenderFactory, CultureDynamicSmsSenderFactory>();
        services.AddSingleton<IConcreteSmsSenderTypeProvider, ConcreteSmsSenderTypeProvider>();

        return services;
    }
}