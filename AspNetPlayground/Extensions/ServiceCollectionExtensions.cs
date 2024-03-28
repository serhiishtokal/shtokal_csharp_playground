using AspNetPlayground.Helpers;
using AspNetPlayground.Services.Senders;
using AspNetPlayground.Services.Senders.ConcreteSmsSenders;
using AspNetPlayground.Services.Senders.ConcreteSmsSenders.SmsSender1s;
using AspNetPlayground.Services.Senders.ConcreteSmsSenders.SmsSender2s;
using AspNetPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders;
using AspNetPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders.Factories;

namespace AspNetPlayground.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSmsSenders(this IServiceCollection services)
    {
        services.AddSingleton<ISmsSender1, SmsSender1>();
        services.Decorate<ISmsSender1, SmsSender1Decorator1>();

        services.AddSingleton<ISmsSender2>(sp =>
        {
            var decoratedSmsSender = DecoratorChainBuilder<ISmsSender2>
                .Create<SmsSender2>(sp)
                .DecorateWith<SmsSender2Decorator1>()
                .Build();

            return decoratedSmsSender;
        });
        
        services.AddSingleton<IConcreteSmsSenderFactory, ConcreteSmsSenderFactory>();

        services.AddSingleton<ISmsSendingStrategy, SmsSendingStrategy>();
        services.Decorate<ISmsSendingStrategy, SmsSendingStrategyLoggingDecorator>();

        services.AddSingleton<ICultureDynamicSmsSenderFactory, CultureDynamicSmsSenderFactory>();
        services.AddSingleton<IConcreteSmsSenderTypeProvider, ConcreteSmsSenderTypeProvider>();

        return services;
    }
}