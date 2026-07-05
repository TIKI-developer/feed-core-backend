namespace Feed.WebApi.Requests;

public readonly record struct LoginRequest
{
    public required string Name { get; init; }
    public required string Password { get; init; }
}
