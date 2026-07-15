using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Requests;

public sealed record CreateRoleRequest
{
    [FromBody] public required CreateRoleRequestBody Body { get; init; }
}

public sealed record CreateRoleRequestBody
{
    public required string Name { get; init; }
    public required ICollection<string> Permissions { get; init; }
}
