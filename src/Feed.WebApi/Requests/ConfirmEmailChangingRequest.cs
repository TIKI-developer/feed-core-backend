using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record ConfirmEmailChangingRequest
{
    [FromQuery] public required string Token { get; init; }
    [FromQuery] public required string NewEmail { get; init; }
}
