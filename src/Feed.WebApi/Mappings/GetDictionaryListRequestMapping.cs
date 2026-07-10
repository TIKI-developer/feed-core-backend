using Feed.Application.UseCases.Users.Queries.GetDictionaries;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class GetDictionaryListRequestMapping
{
    public static GetDictionaryListQuery ToQuery(this GetDictionaryListRequest request)
    {
        return new()
        {
            Pagination = request.Pagination.ToPaginationQuery()
        };
    }
}
