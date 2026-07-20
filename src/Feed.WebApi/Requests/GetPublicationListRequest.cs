namespace Feed.WebApi.Requests;

public sealed record GetPublicationListRequest
{
    public required PaginationRequest Pagination { get; init; }
}
