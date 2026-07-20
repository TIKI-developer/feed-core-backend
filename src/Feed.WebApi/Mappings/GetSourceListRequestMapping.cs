using Feed.Application.UseCases.Publications.Query.GetSourceList;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class GetSourceListRequestMapping
{
    public static GetSourceListQuery ToQuery(this GetSourceListRequest request)
    {
        return new GetSourceListQuery
        {
            Pagination = request.Pagination.ToPaginationQuery()
        };
    }
}
