using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record UpdateDictionaryRequest
{
    [FromBody] public required UpdateDictionaryRequestBody Body { get; init; }
}

public sealed record UpdateDictionaryRequestBody
{
    public required string Name { get; init; }
}
