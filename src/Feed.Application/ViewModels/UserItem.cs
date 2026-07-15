using Feed.Domain.Shared.ValueObjects;

namespace Feed.Application.ViewModels;

public readonly record struct UserItem
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public FullName? FullName { get; init; }
}
