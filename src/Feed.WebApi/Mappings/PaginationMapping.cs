using Feed.Application.Common.Pagination;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class PaginationMapping
{
    public static PaginationQuery ToPaginationQuery(this PaginationRequest request)
    {
        return new PaginationQuery
        {
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
