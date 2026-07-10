using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record PaginationRequest([FromQuery] int Page, [FromQuery] int PageSize);
