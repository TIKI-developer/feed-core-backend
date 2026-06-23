using Feed.Domain.Shared.Interfaces;

namespace Feed.Domain.Shared.ValueObjects;
public sealed record Password
{
    public string Hash => _hash;

    private readonly string _hash;

    private Password(string hash)
    {
        _hash = hash;
    }

    public static Password Restore(string hash)
    {
        return new Password(hash);
    }

    public static Password Create(string raw, IStringHasher hasher)
    {
        var hash = hasher.ComputeHash(raw);

        return new Password(hash);
    }
}