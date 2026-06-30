namespace Feed.WebApi.Requests;

public readonly record struct RegisterRequest
{
    public required string Name { get; init; }
    public required string Password { get; init; }
}
