using Feed.Domain.Users.Entities;
using Feed.Persistence.Entities;

namespace Feed.Persistence.Mappings;

internal static class RoleMapping
{
    public static RoleEntity ToEntity(this Role role)
    {
        return new RoleEntity
        {
            Name = role.Name,
            Permissions = [.. role.Permissions.Select(p => p.ToEntity())]
        };
    }
    public static Role ToDomain(this RoleEntity role)
    {
        return Role.Restore
            (
                role.Name,
                [.. role.Permissions.Select(e => e.ToDomain())]
            );
    }
}
