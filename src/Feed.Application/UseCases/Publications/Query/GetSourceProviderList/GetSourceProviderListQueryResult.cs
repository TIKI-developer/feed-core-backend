using Feed.Application.ViewModels;

namespace Feed.Application.UseCases.Publications.Query.GetSourceProviderList;

public readonly record struct GetSourceProviderListQueryResult
{
    public required ICollection<SourceProviderItem> SourceProviders { get; init; }
}
