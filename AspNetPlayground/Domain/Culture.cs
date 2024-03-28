namespace AspNetPlayground.Domain;

public record Culture(string Name)
{
    public static Culture Create(string name) => new(name);
}