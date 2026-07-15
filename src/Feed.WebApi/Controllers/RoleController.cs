using Feed.WebApi.Interfaces;
using Feed.WebApi.Mappings;
using Feed.WebApi.Requests;
using Feed.WebApi.Responses;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

[Route("roles")]
public class RoleController
    (
        IMediator mediator,
        ICurrentUser currentUser
    )
    :
    BaseController
    (
        mediator,
        currentUser
    )
{
    [HttpPost]
    public async Task<ActionResult<Response>> Create
    (
        [FromBody] CreateRoleRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = request.ToCommand();
        await Mediator.Send(command, cancellationToken);
        var response = new Response();

        return Ok(response);
    }
}
