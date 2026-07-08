using Feed.Domain.Shared.ValueObjects;

namespace Feed.Application.ViewModels;

public readonly record struct UserDetails
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string? Email { get; init; }
    public FullName? FullName { get; init; }
    public ICollection<string>? Roles { get; init; }
}
