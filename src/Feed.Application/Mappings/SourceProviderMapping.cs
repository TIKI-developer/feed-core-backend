using Feed.Application.ViewModels;
using Feed.Plugin.Abstractions;

namespace Feed.Application.Mappings;

internal static class SourceProviderMapping
{
    public static SourceProviderItem ToItem(this ISourceProvider sourceProvider)
    {
        return new SourceProviderItem
        {
            Name = sourceProvider.Name
        };
    }
}
