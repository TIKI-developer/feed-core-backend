using Feed.Plugin.Abstractions;

namespace Feed.Vk;

public class VkSourceProvider : ISourceProvider
{
    public string Name => "vk";

    public string BuildPublicationUrl(string sourceExternalId, string externalId)
    {
        return $"https://vk.ru/{sourceExternalId}/{externalId}";
    }

    public string BuildSourceUrl(string externalId)
    {
        return $"https://vk.ru/{externalId}";
    }

    public async Task<ICollection<PublicationDto>> GetNewPublicationAsync(string sourceExternalId, DateTime lastCheckedAt)
    {
        var publications = new List<PublicationDto>()
        {
            new() {
                Body = "Публикация",
                ExternalId = "10010393",
                PublishedAt = DateTime.UtcNow,
            }
        };

        return publications;
    }
}
