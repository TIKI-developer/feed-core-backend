namespace Feed.Domain.Users.Entities;

public sealed record UserToken
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public byte[] TokenHash { get; init; } = default!;
    public DateTime ExpiredAt { get; init; }
    public UserTokenPurpose Purpose { get; init; }

    public static UserToken Create
        (Guid userId,
        byte[] tokenHash,
        DateTime expiredAt,
        UserTokenPurpose purpose)
    {
        return new UserToken
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            TokenHash = tokenHash,
            ExpiredAt = expiredAt,
            Purpose = purpose
        };
    }
}

public enum UserTokenPurpose
{
    EmailConfirmation
}
