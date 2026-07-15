using Feed.Application.ViewModels;

namespace Feed.WebApi.Responses;

public readonly record struct GetRoleListResponse
{
    public required ICollection<RoleItem> Roles { get; init; }
}
