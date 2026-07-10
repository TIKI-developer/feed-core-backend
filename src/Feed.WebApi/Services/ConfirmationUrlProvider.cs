using Feed.Application.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace Feed.WebApi.Services;

internal sealed class ConfirmationUrlProvider(IHttpContextAccessor httpContextAccessor) : IConfirmationUrlProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Uri BuildConfirmationUrl(string? baseUrl, string token, string newEmail)
    {
        var query = new Dictionary<string, string?>
        {
            ["token"] = token,
            ["newEmail"] = newEmail
        };

        if (!string.IsNullOrWhiteSpace(baseUrl) &&
            Uri.TryCreate(baseUrl, UriKind.Absolute, out _))
        {
            return new Uri(
                QueryHelpers.AddQueryString(baseUrl, query),
                UriKind.Absolute);
        }

        var request = _httpContextAccessor.HttpContext?.Request;

        var origin = request is null
            ? null
            : $"{request.Scheme}://{request.Host}";

        if (origin is null)
            throw new InvalidOperationException(
                "Unable to determine confirmation URL.");

        return new Uri(
            QueryHelpers.AddQueryString($"{origin}/auth/confirm-email/", query),
            UriKind.Absolute);
    }
}
