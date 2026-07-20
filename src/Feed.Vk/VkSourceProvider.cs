using Feed.Plugin.Abstractions;

namespace Feed.Vk;

public class VkSourceProvider : ISourceProvider
{
    public string Name => "Vkontakte";

    public string BuildPublicationUrl(string sourceExternalId, string externalId)
    {
        return $"https://vk.ru/{sourceExternalId}/{externalId}";
    }

    public string BuildSourceUrl(string externalId)
    {
        return $"https://vk.ru/{externalId}";
    }
}
