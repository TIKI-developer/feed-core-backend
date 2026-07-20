namespace Feed.WebApi.Responses;

public sealed record CreateSourceResponse
{
    public required Guid Id { get; set; }
}
