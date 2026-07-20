using Feed.Application.Common.Pagination;
using Feed.Application.ViewModels;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetPublicationList;

public readonly record struct GetPublicationListQuery : IQuery<PagedList<PublicationItem>>
{
    public required PaginationQuery Pagination { get; init; }
}
