namespace Feed.Application.Common.Pagination;

public sealed record PaginationQuery
{
    public int Page { get; init; }
    public int PageSize { get; init; }
}
