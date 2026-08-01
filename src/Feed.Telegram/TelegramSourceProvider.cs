using Feed.Plugin.Abstractions;
using TL;
using WTelegram;

namespace Feed.Telegram;

public sealed class TelegramSourceProvider(Client client) : ISourceProvider
{
    public string Name => "telegram";

    public string BuildSourceUrl(string externalId)
        => $"https://t.me/{externalId}";

    public string BuildPublicationUrl(string sourceExternalId, string externalId)
        => $"https://t.me/{sourceExternalId}/{externalId}";

    public async Task<ICollection<PublicationDto>> GetNewPublicationAsync(
        string sourceExternalId,
        DateTime lastCheckedAt)
    {
        sourceExternalId = sourceExternalId.TrimStart('@');

        var resolved = await client.Contacts_ResolveUsername(sourceExternalId);

        if (resolved.Chat is not Channel channel)
            return [];

        var history = await client.Messages_GetHistory(
            peer: channel,
            limit: 100);

        var publications = new List<PublicationDto>();

        foreach (var messageBase in history.Messages)
        {
            if (messageBase is not Message message)
                continue;

            var publishedAt = message.Date;

            if (publishedAt <= lastCheckedAt)
                continue;

            publications.Add(new PublicationDto
            {
                ExternalId = message.ID.ToString(),
                PublishedAt = publishedAt,
                Body = message.message,
            });
        }

        return publications;
    }
}
