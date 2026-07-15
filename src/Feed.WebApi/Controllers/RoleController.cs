using Feed.Application.UseCases.Users.Queries.GetRoleList;
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
    [HttpGet]
    public async Task<ActionResult<Response<GetRoleListQueryResult>>> Get
    (
        CancellationToken cancellationToken
    )
    {
        var query = new GetRoleListQuery();
        var result = await Mediator.Send(query, cancellationToken);
        var response = new Response<GetRoleListResponse>(result.ToResponse());

        return Ok(response);
    }

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
