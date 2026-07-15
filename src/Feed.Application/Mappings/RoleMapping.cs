using Feed.Application.ViewModels;
using Feed.Domain.Users.Entities;

namespace Feed.Application.Mappings;

internal static class RoleMapping
{
    public static RoleItem ToItem(this Role role)
    {
        return new RoleItem
        {
            Name = role.Name
        };
    }
}
