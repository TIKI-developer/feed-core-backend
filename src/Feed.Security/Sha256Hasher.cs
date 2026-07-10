using Feed.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Feed.Security;

internal class Sha256Hasher : ITokenHasher
{
    public byte[] Hash(string raw)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(raw);
        byte[] hash = SHA256.HashData(bytes);

        return hash;
    }
}
