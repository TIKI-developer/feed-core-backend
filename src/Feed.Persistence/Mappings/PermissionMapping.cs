using Feed.Domain.Users.ValueObjects;
using Feed.Persistence.Entities;

namespace Feed.Persistence.Mappings;

internal static class PermissionMapping
{
    public static PermissionEntity ToEntity(this Permission permission)
    {
        return new PermissionEntity
        {
            Name = permission.Name
        };
    }
    public static Permission ToDomain(this PermissionEntity entity)
    {
        return new Permission
        {
            Name = entity.Name
        };
    }
}
