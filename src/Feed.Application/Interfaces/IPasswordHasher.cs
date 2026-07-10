namespace Feed.Application.Interfaces;

public interface IPasswordHasher
{
    string Hash(string raw);
    bool Verify(string raw, string hash);
}
