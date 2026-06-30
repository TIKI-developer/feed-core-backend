using Feed.Domain.Users.Entities;
using Feed.Persistence.Entities;

namespace Feed.Persistence.Mappings;


public static class UserMapper
{
    public static UserEntity ToEntity(this User user)
    {
        return new UserEntity
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            FullName = user.Profile?.FullName,
            Roles = [.. user.Roles]
        };
    }

    public static User ToDomain(this UserEntity entity)
    {
        return User.Restore
        (
            entity.Id,
            entity.Name,
            entity.Password,
            entity.Email,
            new Profile
            (
                entity.FullName
            ),
            entity.Roles
        );
    }
}