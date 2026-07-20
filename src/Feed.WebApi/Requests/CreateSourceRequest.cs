using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record CreateSourceRequest
{
    [FromBody] public required CreateSourceRequestBody Body { get; init; }
}

public sealed record CreateSourceRequestBody
{
    public required string Name { get; init; }
    public required string ExternalId { get; init; }
    public required string SourceProviderName { get; init; }
}
