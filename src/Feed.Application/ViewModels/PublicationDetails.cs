using Feed.Domain.Shared.ValueObjects;

namespace Feed.Application.ViewModels;

public readonly record struct PublicationDetails
{
    public required Guid Id { get; init; }
    public required string ExternalId { get; init; }
    public required string Body { get; init; }
    public required Guid SourceId { get; init; }
    public required DateTime PublishedAt { get; init; }
    public required Timestamps Timestamps { get; init; }
}
