using Feed.Application.ViewModels;
using Feed.Domain.Publications.Entities;

namespace Feed.Application.Mappings;

internal static class PublicationMapping
{
    public static PublicationItem ToItem(this Publication item)
    {
        return new PublicationItem
        {
            Id = item.Id,
            ExternalId = item.ExternalId,
            Body = item.Body,
            PublishedAt = item.PublishedAt,
        };
    }
}
