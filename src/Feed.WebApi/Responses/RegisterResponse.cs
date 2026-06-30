namespace Feed.WebApi.Responses;

public readonly record struct RegisterResponse
{
    public required string AccessToken { get; init; }
}