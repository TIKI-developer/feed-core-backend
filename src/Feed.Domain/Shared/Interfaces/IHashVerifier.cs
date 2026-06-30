namespace Feed.Domain.Shared.Interfaces;

public interface IHashVerifier
{
    bool Verify(string raw, string hash);
}
