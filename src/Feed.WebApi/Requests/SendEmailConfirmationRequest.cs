using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record SendEmailConfirmationRequest
{
    [FromBody] public required SendEmailConfirmationRequestBody Body { get; init; }
}

public sealed record SendEmailConfirmationRequestBody
{
    public required string Email { get; init; }
    public string? ConfirmationUrl { get; init; }
}
