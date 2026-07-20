using Feed.Domain.Shared.ValueObjects;

namespace Feed.Application.UseCases.Publications.Query.GetSourceList;

public readonly record struct SourceItem
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Url { get; init; }
    public required string SourceProviderName { get; init; }
    public required DateTime LastCheckedAt { get; init; }
}
