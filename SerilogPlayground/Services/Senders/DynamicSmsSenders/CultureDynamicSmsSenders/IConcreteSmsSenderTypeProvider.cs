using System.Globalization;
using SerilogPlayground.Domain;
using SerilogPlayground.Services.Senders.ConcreteSmsSenders;

namespace SerilogPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders;

public interface IConcreteSmsSenderTypeProvider
{
    ConcreteSmsSenderType GetSenderType(Culture culture);
}