using Feed.WebApi.Mappings;
using Feed.WebApi.Requests;
using Feed.WebApi.Responses;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

[Route("auth")]
public class AuthController
    (
        IMediator mediator
    )
    :
    BaseController
    (
        mediator
    )
{
    [HttpPost("register")]
    public async Task<ActionResult<Response<RegisterResponse>>> Register
        (
            [FromBody] RegisterRequest request,
            CancellationToken cancellationToken
        )
    {
        var command = request.ToCommand();
        var result = await Mediator.Send(command, cancellationToken);
        var response = new Response<RegisterResponse>(result.ToResponse());

        return Ok(response);
    }
}
