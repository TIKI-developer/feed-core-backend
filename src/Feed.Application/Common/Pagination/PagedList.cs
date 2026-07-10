namespace Feed.Application.Common.Pagination;

public class PagedList<T>(IReadOnlyList<T> items,
                          int page,
                          int pageSize,
                          int totalCount)
{
    public IReadOnlyList<T> Items { get; } = items;
    public int Page { get; init; } = page;
    public int PageSize { get; init; } = pageSize;
    public int TotalCount { get; init; } = totalCount;
    public bool HasNextPage => Page * PageSize < TotalCount;
    public bool HasPreviousPage => Page > 1;

    public PagedList<TResult> Select<TResult>(Func<T, TResult> selector)
    {
        return new PagedList<TResult>(
            [.. Items.Select(selector)],
            Page,
            PageSize,
            TotalCount);
    }
}
