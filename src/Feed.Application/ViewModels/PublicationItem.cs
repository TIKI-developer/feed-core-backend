namespace Feed.Application.ViewModels;

public readonly record struct PublicationItem
{
    public required Guid Id { get; init; }
    public required string ExternalId { get; init; }
    public required string Body { get; init; }
    public required DateTime PublishedAt { get; init; }
}
