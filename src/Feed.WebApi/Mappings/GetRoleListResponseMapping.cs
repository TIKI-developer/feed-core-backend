using Feed.Application.UseCases.Users.Queries.GetRoleList;
using Feed.WebApi.Responses;

namespace Feed.WebApi.Mappings;

public static class GetRoleListResponseMapping
{
    public static GetRoleListResponse ToResponse(this GetRoleListQueryResult result)
    {
        return new GetRoleListResponse
        {
            Roles = result.Roles
        };
    }
}
