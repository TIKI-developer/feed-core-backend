namespace Feed.Application.Interfaces;

public interface ITokenHasher
{
    byte[] Hash(string raw);
}
