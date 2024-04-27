namespace Domain.Entities;

public class Actor(string? name, string? details, string? type, int rank, string? source)
{
    public string Id { get; private set; }
    public string? Name { get; private set; } = name;
    public string? Details { get; private set; } = details;
    public string? Type { get; private set; } = type;
    public int Rank { get; private set; } = rank;
    public string? Source { get; private set; } = source;
}

