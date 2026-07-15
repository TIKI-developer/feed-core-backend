using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record RemoveWordsFromDictionaryRequest
{
    [FromBody] public required RemoveWordsFromDictionaryRequestBody Body { get; init; }
}

public sealed record RemoveWordsFromDictionaryRequestBody
{
    public required ICollection<string> Words { get; init; }
}
