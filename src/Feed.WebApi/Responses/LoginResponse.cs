namespace Feed.WebApi.Responses;

public readonly record struct LoginResponse
{
    public required string AccessToken { get; init; }
}
