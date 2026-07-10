using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record RegisterRequest
{
    [FromBody] public required RegisterBody Body { get; init; }
}

public sealed record RegisterBody
{
    public required string Name { get; init; }
    public required string Password { get; init; }
}
