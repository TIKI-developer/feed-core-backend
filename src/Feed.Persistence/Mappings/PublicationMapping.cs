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

    public static PublicationEntity ToEntity(this Publication publication)
    {
        return new PublicationEntity
        {
            Id = publication.Id,
            Body = publication.Body,
            ExternalId = publication.ExternalId,
            PublishedAt = publication.PublishedAt,
            SourceId = publication.SourceId,
            Timestamps = publication.Timestamps
        };
    }
}
