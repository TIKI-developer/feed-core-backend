namespace Feed.Domain.Publications;

public class Source
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ExternalId { get; private set; }
    public SourceProvider Provider { get; private set; }
    public DateTime LastCheckedAt { get; private set; }

    private Source(Guid id, string name, string externalId, SourceProvider provider)
    {
        Id = id;
        Name = name;
        ExternalId = externalId;
        Provider = provider;
    }

    public static Source Create(string name, string externalId, SourceProvider provider)
    {
        return new Source(Guid.NewGuid(), name, externalId, provider);
    }

    public static Source Restore(Guid id, string name, string externalId, SourceProvider provider)
    {
        return new Source(id, name, externalId, provider);
    }

    public void Update(string name)
    {
        Name = name;
    }   

    public IEnumerable<Publication> GetNewPublications()
    {
        return Provider.GetNewPublications(ExternalId, LastCheckedAt);
    }
}