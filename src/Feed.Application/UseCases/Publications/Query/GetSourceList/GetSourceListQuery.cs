using Feed.Application.Common.Pagination;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetSourceList
{
    public readonly record struct GetSourceListQuery : IQuery<GetSourceListQueryResult>
    {
        public required PaginationQuery Pagination { get; init; }
    }
}
