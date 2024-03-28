using System.Globalization;
using SerilogPlayground.Domain;

namespace SerilogPlayground.Services.Senders.DynamicSmsSenders.CultureDynamicSmsSenders.Factories;

public interface ICultureDynamicSmsSenderFactory
{
    ISmsSender GetSmsSender(Culture culture);
}