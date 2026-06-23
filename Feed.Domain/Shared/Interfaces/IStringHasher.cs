namespace Feed.Domain.Shared.Interfaces;

public interface IStringHasher
{
    string ComputeHash(string raw);
}