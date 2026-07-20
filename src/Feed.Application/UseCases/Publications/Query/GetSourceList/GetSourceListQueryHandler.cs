using Feed.Application.Common.Pagination;
using Feed.Application.Interfaces;
using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetSourceList;

internal sealed class GetSourceListQueryHandler
    (ISourceRepository sourceRepository,
    ISourceProviderRegistry sourceProviderRegistry)
    : IQueryHandler<GetSourceListQuery, GetSourceListQueryResult>
{
    public async ValueTask<GetSourceListQueryResult> Handle(
        GetSourceListQuery query,
        CancellationToken cancellationToken)
    {
        var sources = await sourceRepository.GetPagedAsync(query.Pagination.Page, query.Pagination.PageSize, cancellationToken);

        return new()
        {
            Sources = new PagedList<SourceItem>
            (
                [.. sources.Items
                    .Select(s => s.ToItem(
                        sourceProviderRegistry
                            .Get(s.SourceProviderName)?
                            .BuildSourceUrl(s.ExternalId) ?? "no url"))],
                sources.Page,
                sources.PageSize,
                sources.TotalCount
            )
        };
    }
}