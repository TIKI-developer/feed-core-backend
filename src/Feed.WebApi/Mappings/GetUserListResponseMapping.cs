using Feed.Application.UseCases.Users.Queries.GetUserList;
using Feed.WebApi.Responses;

namespace Feed.WebApi.Mappings;

public static class GetUserListResponseMapping
{
    public static GetUserListResponse ToResponse(this GetUserListQueryResult response)
    {
        return new GetUserListResponse
        {
            Users = response.Users,
        };
    }
}
