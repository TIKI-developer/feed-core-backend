using Feed.Application.ViewModels;
using Feed.Domain.Users.Entities;

namespace Feed.Application.Mappings;

public static class UserMapping
{
    public static UserDetails ToDetails(this User user/*, ICollection<Role> roles*/)
    {
        return new UserDetails
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email?.Value ?? string.Empty,
            FullName = user.Profile?.FullName,
            //Roles = roles.Any(role => role.Name).Select(role => role.Name)
        };
    }
}

