using Feed.Domain.Shared.ValueObjects;

namespace Feed.Persistence.Entities;

public class SourceEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ExternalId { get; set; }
    public required string SourceProviderName { get; set; }
    public required DateTime LastCheckedAt { get; set; }
    public required Timestamps Timestamps { get; set; }
}
