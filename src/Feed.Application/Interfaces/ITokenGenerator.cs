namespace Feed.Application.Interfaces;

public interface ITokenGenerator
{
    string Generate(int length = 32);
}
