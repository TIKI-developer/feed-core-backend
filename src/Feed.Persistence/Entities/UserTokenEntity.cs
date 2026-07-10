using Feed.Domain.Users.Entities;

namespace Feed.Persistence.Entities;

internal sealed class UserTokenEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public byte[] TokenHash { get; set; } = default!;
    public DateTime ExpiredAt { get; set; }
    public UserTokenPurpose Purpose { get; set; }
}
