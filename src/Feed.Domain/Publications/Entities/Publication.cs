using Feed.Domain.Shared.ValueObjects;

namespace Feed.Domain.Publications.Entities;

public class Publication
{
    public Guid Id { get; private set; }
    public string ExternalId { get; private set; }
    public string Body { get; private set; }
    public Guid SourceId { get; private set; }
    public DateTime PublishedAt { get; private set; }
    public Timestamps Timestamps { get; private set; }

    private Publication
        (
            Guid id,
            string externalId,
            string body,
            Guid sourceId,
            DateTime publishedAt,
            Timestamps timestamps
        )
    {
        Id = id;
        ExternalId = externalId;
        Body = body;
        SourceId = sourceId;
        PublishedAt = publishedAt;
        Timestamps = timestamps;
    }

    public static Publication Create(string externalId, string body, Guid sourceId, DateTime publishedAt)
    {
        return new Publication(Guid.NewGuid(), externalId, body, sourceId, publishedAt, Timestamps.Create());
    }

    public static Publication Restore(Guid id, string externalId, string body, Guid sourceId, DateTime publishedAt, Timestamps timestamps)
    {
        return new Publication(id, externalId, body, sourceId, publishedAt, timestamps);
    }
}
