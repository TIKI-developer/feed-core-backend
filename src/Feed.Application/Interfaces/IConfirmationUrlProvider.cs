namespace Feed.Application.Interfaces;

public interface IConfirmationUrlProvider
{
    Uri BuildConfirmationUrl(string? baseUrl, string token, string newEmail);
}
