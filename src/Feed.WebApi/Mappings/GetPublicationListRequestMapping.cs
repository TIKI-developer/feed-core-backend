using Feed.Application.UseCases.Publications.Query.GetPublicationList;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class GetPublicationListRequestMapping
{
    public static GetPublicationListQuery ToQuery(this GetPublicationListRequest request)
    {
        return new GetPublicationListQuery
        {
            Pagination = request.Pagination.ToPaginationQuery()
        };
    }
}
