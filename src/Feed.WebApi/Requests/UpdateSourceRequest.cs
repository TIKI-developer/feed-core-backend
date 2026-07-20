using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record UpdateSourceRequest
{
    [FromBody] public required UpdateSourceRequestBody Body { get; init; }
}

public sealed record UpdateSourceRequestBody
{
    public required string Name { get; init; }
}
