using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public class ChangePasswordRequest
{
    [FromBody] public required ChangePasswordRequestBody Body { get; init; }
}

public class ChangePasswordRequestBody
{
    public required string CurrentPassword { get; init; }
    public required string NewPassword { get; init; }
}
