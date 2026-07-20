using Feed.Domain.Shared.ValueObjects;

namespace Feed.Domain.Publications.Entities;

public class Source
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ExternalId { get; private set; }
    public string SourceProviderName { get; private set; }
    public DateTime LastCheckedAt { get; private set; }
    public Timestamps Timestamps { get; private set; }

    private Source(Guid id, string name, string externalId, string sourceProviderName, Timestamps timestamps)
    {
        Id = id;
        Name = name;
        ExternalId = externalId;
        SourceProviderName = sourceProviderName;
        Timestamps = timestamps;
    }

    public static Source Create(string name, string externalId, string sourceProviderName)
    {
        return new Source(Guid.NewGuid(), name, externalId, sourceProviderName, Timestamps.Create());
    }

    public static Source Restore(Guid id, string name, string externalId, string sourceProviderName, Timestamps timestamps)
    {
        return new Source(id, name, externalId, sourceProviderName, timestamps);
    }

    public void Update(string name)
    {
        Name = name;
        Timestamps.Touch();
    }
}
