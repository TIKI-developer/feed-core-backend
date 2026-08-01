namespace Feed.Plugin.Abstractions;

public interface ISourceProvider
{
    string Name { get; }
    string BuildSourceUrl(string externalId);
    string BuildPublicationUrl(string sourceExternalId, string externalId);
    Task<ICollection<PublicationDto>> GetNewPublicationAsync(string sourceExternalId, DateTime lastCheckedAt);
}
