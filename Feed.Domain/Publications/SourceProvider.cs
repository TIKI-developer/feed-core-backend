namespace Feed.Domain.Publications;

public abstract class SourceProvider
{
    public abstract string UniqueName { get; }
    public abstract IEnumerable<Publication> GetNewPublications(string externalId, DateTime lastPublicationDate);
    public abstract string BuildSourceUrl(string externalId);
    public abstract string BuildPublicationUrl(string sourceExternalId, string externalId);
}