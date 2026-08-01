using Feed.Domain.Shared.ValueObjects;

namespace Feed.Persistence.Entities;

internal class PublicationEntity
{
    public required Guid Id { get; set; }
    public required string ExternalId { get; set; }
    public required string Body { get; set; }
    public required Guid SourceId { get; set; }
    internal SourceEntity Source { get; set; } = null!;
    public required DateTime PublishedAt { get; set; }
    public required Timestamps Timestamps { get; set; }
}
