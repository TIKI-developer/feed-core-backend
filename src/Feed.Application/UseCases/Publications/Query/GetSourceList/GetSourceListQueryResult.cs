using Feed.Application.Common.Pagination;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetSourceList;

public readonly record struct GetSourceListQueryResult
{
    public required PagedList<SourceItem> Sources { get; init; }
}
