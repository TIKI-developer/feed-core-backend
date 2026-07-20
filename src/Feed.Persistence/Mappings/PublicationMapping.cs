using Feed.Domain.Publications.Entities;
using Feed.Persistence.Entities;

namespace Feed.Persistence.Mappings;

internal static class PublicationMapping
{
    public static Publication ToDomain(this PublicationEntity entity)
    {
        return Publication.Restore
            (
                entity.Id,
                entity.ExternalId,
                entity.Body,
                entity.SourceId,
                entity.PublishedAt,
                entity.Timestamps
            );
    }
}
