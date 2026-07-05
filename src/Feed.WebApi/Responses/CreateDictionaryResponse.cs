namespace Feed.WebApi.Responses;

public readonly record struct CreateDictionaryResponse
{
    public required Guid Id { get; init; }
}
