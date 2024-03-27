namespace SerilogPlayground.Domain;

public record Message(string Content, string ToPhoneNumber) : IMessage;