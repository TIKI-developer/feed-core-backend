using Feed.Application.Common.Pagination;
using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Feed.Application.ViewModels;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetPublicationList;

internal sealed class GetPublicationListQueryHandler
    (IPublicationRepository publicationRepository)
    : IQueryHandler<GetPublicationListQuery, PagedList<PublicationItem>>
{
    public async ValueTask<PagedList<PublicationItem>> Handle(
        GetPublicationListQuery query,
        CancellationToken cancellationToken)
    {
        var publicationPagedList = await publicationRepository.GetPagedListAsync(query.Pagination.Page, query.Pagination.PageSize, cancellationToken);

        return new PagedList<PublicationItem>
            (
                [.. publicationPagedList.Items.Select(e => e.ToItem())],
                publicationPagedList.Page,
                publicationPagedList.PageSize,
                publicationPagedList.TotalCount
            );
    }
}
