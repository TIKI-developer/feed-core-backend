using Feed.Application.Interfaces;
using System.Security.Cryptography;

namespace Feed.Security;

internal sealed class TokenGenerator : ITokenGenerator
{
    public string Generate(int length = 32)
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        return token;
    }
}
