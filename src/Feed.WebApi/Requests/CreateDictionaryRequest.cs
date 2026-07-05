namespace Feed.WebApi.Requests;

public readonly record struct CreateDictionaryRequest
{
    public required string Name { get; init; }
}
