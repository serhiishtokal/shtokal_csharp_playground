using System.Globalization;
using SerilogPlayground.Domain;
using SerilogPlayground.Services.Senders.ConcreteSmsSenders;

namespace SerilogPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders;

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