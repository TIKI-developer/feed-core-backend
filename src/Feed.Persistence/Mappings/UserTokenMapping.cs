using Feed.Domain.Users.Entities;
using Feed.Persistence.Entities;

namespace Feed.Persistence.Mappings;

internal static class UserTokenMapping
{
    public static UserTokenEntity ToEntity(this UserToken token)
    {
        return new UserTokenEntity
        {
            Id = token.Id,
            UserId = token.UserId,
            TokenHash = token.TokenHash,
            ExpiredAt = token.ExpiredAt,
            Purpose = token.Purpose
        };
    }

    public static UserToken ToDomain(this UserTokenEntity entity)
    {
        return new UserToken
        {
            Id = entity.Id,
            UserId = entity.UserId,
            TokenHash = entity.TokenHash,
            ExpiredAt = entity.ExpiredAt,
            Purpose = entity.Purpose
        };
    }
}
