using AspNetPlayground.Domain;

namespace AspNetPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders.Factories;

public class CultureDynamicSmsSenderFactory: ICultureDynamicSmsSenderFactory
{
    private readonly IServiceProvider _serviceProvider;
    public CultureDynamicSmsSenderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public ISmsSender GetSmsSender(Culture culture)
    {
        return ActivatorUtilities.CreateInstance<CultureDynamicSmsSender>(_serviceProvider, culture); 
    }
}