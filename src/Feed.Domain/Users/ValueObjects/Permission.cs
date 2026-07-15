namespace Feed.Domain.Users.ValueObjects;

public record Permission
{
    public required string Name { get; init; }
}
