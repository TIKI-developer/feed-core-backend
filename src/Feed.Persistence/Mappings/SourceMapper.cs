using Feed.Domain.Publications.Entities;
using Feed.Persistence.Entities;

namespace Feed.Persistence.Mappings;

internal static class SourceMapper
{
    public static SourceEntity ToEntity(this Source source)
    {
        return new SourceEntity
        {
            Id = source.Id,
            Name = source.Name,
            ExternalId = source.ExternalId,
            LastCheckedAt = source.LastCheckedAt,
            SourceProviderName = source.SourceProviderName,
            Timestamps = source.Timestamps,
        };
    }
}
