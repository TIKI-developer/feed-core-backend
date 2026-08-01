namespace Feed.Plugin.Abstractions;

public readonly record struct PublicationDto
{
    public required string ExternalId { get; init; }
    public required string Body { get; init; }
    public required DateTime PublishedAt { get; init; }
}
