using AspNetPlayground.Domain;
using AspNetPlayground.Services.Senders.ConcreteSmsSenders;

namespace AspNetPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders;

public class ConcreteSmsSenderTypeProvider: IConcreteSmsSenderTypeProvider
{
    public ConcreteSmsSenderType GetSenderType(Culture culture)
    {
        return culture.Name switch
        {
            "es-ES" => ConcreteSmsSenderType.SmsSender1,
            "fr-FR" => ConcreteSmsSenderType.SmsSender2,
            _ => ConcreteSmsSenderType.SmsSender1
        };
    }
}