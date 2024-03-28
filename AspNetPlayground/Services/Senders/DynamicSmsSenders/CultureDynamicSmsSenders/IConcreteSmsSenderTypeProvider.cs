using AspNetPlayground.Domain;
using AspNetPlayground.Services.Senders.ConcreteSmsSenders;

namespace AspNetPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders;

public interface IConcreteSmsSenderTypeProvider
{
    ConcreteSmsSenderType GetSenderType(Culture culture);
}