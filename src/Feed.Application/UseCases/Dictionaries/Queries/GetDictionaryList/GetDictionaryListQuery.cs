
using Feed.Application.Common.Pagination;
using Mediator;

namespace Feed.Application.UseCases.Users.Queries.GetDictionaries;

public readonly record struct GetDictionaryListQuery : IQuery<GetDictionaryListQueryResult>
{
    public required PaginationQuery Pagination { get; init; }
}
