using Feed.Application.UseCases.Publications.Query.GetSourceList;
using Feed.Application.ViewModels;
using Feed.Domain.Publications.Entities;

namespace Feed.Application.Mappings;

internal static class SourceMapping
{
    public static SourceItem ToItem(this Source source, string url)
    {
        return new SourceItem
        {
            Id = source.Id,
            Name = source.Name,
            Url = url,
            LastCheckedAt = source.LastCheckedAt,
            SourceProviderName = source.SourceProviderName
        };
    }

    public static SourceDetails ToDetails(this Source source)
    {
        return new SourceDetails
        {
            Id = source.Id,
            Name = source.Name,
            ExternalId = source.ExternalId,
            LastCheckedAt = source.LastCheckedAt,
            SourceProviderName = source.SourceProviderName,
            Timestamps = source.Timestamps,
        };
    }
}
