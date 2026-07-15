using Feed.Application.ViewModels;

namespace Feed.Application.UseCases.Users.Queries.GetRoleList;

public readonly record struct GetRoleListQueryResult
{
    public required ICollection<RoleItem> Roles { get; init; }
}
