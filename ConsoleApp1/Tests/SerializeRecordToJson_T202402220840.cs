using System;
using System.Text.Json;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Tests;

public class SerializeRecordToJson_T202402220840 : ITest
{
    private record PrimotextoSmsSenderMessage(
        string Message,
        string? Sender,
        string? CampaignName,
        string? Category,
        long? Date)
    {
        public string Serialize(JsonSerializerOptions? options = null)
        {
            options ??= new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(this, options);
            return json;
        }
    }
    
    public void Test()
    {
        var record = new PrimotextoSmsSenderMessage("message", "sender", "campaign", "category", 1234567890);
        var jsonString = record.Serialize();
        Console.WriteLine(jsonString);
    }
}