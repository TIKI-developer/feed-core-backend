namespace Feed.Domain.Users;

public record Permission
{
    public required string Name { get; init; }
}