namespace Feed.Domain.Publications;

public class Publication
{
    public Guid Id { get; private set; }
    public string ExternalId { get; private set; }
    public string Body { get; private set; }
    public Guid SourceId { get; private set; }

    private Publication
        (
            Guid id,
            string externalId,
            string body,
            Guid sourceId
        )
    {
        Id = id;
        ExternalId = externalId;
        Body = body;
        SourceId = sourceId;
    }

    public static Publication Create(string externalId, string body, Guid sourceId)
    {
        return new Publication(Guid.NewGuid(), externalId, body, sourceId);
    }

    public static Publication Restore(Guid id, string externalId, string body, Guid sourceId)
    {
        return new Publication(id, externalId, body, sourceId);
    }
}