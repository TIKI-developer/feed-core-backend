using Feed.Domain.Shared.ValueObjects;

namespace Feed.Domain.Publications.Entities;

public class Source
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ExternalId { get; private set; }
    public SourceProvider Provider { get; private set; }
    public DateTime LastCheckedAt { get; private set; }
    public Timestamps Timestamps { get; private set; }

    private Source(Guid id, string name, string externalId, SourceProvider provider, Timestamps timestamps)
    {
        Id = id;
        Name = name;
        ExternalId = externalId;
        Provider = provider;
        Timestamps = timestamps;
    }

    public static Source Create(string name, string externalId, SourceProvider provider)
    {
        return new Source(Guid.NewGuid(), name, externalId, provider, Timestamps.Create());
    }

    public static Source Restore(Guid id, string name, string externalId, SourceProvider provider, Timestamps timestamps)
    {
        return new Source(id, name, externalId, provider, timestamps);
    }

    public void Update(string name)
    {
        Name = name;
        Timestamps.Touch();
    }

    public IEnumerable<Publication> GetNewPublications()
    {
        return Provider.GetNewPublications(ExternalId, LastCheckedAt);
    }
}
