using Feed.Domain.Shared.Interfaces;

namespace Feed.Security;

public class PasswordHasher : IStringHasher, IHashVerifier
{
    public string ComputeHash(string raw)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(raw);
    }

    public bool Verify(string raw, string hash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(raw, hash);
    }
}
