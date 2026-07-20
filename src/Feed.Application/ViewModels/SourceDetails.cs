using Feed.Domain.Shared.ValueObjects;

namespace Feed.Application.ViewModels;

public readonly record struct SourceDetails
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string ExternalId { get; init; }
    public required string SourceProviderName { get; init; }
    public required DateTime LastCheckedAt { get; init; }
    public required Timestamps Timestamps { get; init; }
}
