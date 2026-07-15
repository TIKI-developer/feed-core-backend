using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record AddWordsToDictionaryRequest
{
    [FromBody] public required AddWordsToDictionaryRequestBody Body { get; init; }
}

public sealed record AddWordsToDictionaryRequestBody
{
    public required ICollection<string> Words { get; init; }
}
