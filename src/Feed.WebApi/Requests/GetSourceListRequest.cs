using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record GetSourceListRequest
{
    public required GetSourceListRequestBody Body { get; init; }
}

public sealed record GetSourceListRequestBody
{
    public required PaginationRequest Pagination { get; init; }
}
