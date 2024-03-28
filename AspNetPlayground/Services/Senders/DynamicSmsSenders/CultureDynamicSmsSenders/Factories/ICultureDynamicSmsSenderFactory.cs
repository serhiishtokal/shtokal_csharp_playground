using AspNetPlayground.Domain;

namespace AspNetPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders.Factories;

public interface ICultureDynamicSmsSenderFactory
{
    ISmsSender GetSmsSender(Culture culture);
}