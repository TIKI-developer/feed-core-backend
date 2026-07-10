using Feed.Application.Interfaces;

namespace Feed.Security;

internal class BCryptHasher : IPasswordHasher
{
    public string Hash(string raw)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(raw);
    }

    public bool Verify(string raw, string hash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(raw, hash);
    }
}
