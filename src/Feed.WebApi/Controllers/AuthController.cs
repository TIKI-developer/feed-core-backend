using Feed.WebApi.Interfaces;
using Feed.WebApi.Mappings;
using Feed.WebApi.Requests;
using Feed.WebApi.Responses;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

[Route("auth")]
public class AuthController
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
    [HttpPost("register")]
    public async Task<ActionResult<Response<RegisterResponse>>> Register
        (
            RegisterRequest request,
            CancellationToken cancellationToken
        )
    {
        var command = request.ToCommand();
        var result = await Mediator.Send(command, cancellationToken);
        var response = new Response<RegisterResponse>(result.ToResponse());

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<Response<LoginResponse>>> Login
    (
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = request.ToCommand();
        var result = await Mediator.Send(command, cancellationToken);
        var response = new Response<LoginResponse>(result.ToResponse());

        return Ok(response);
    }

    [HttpPost("send-email-confirmation")]
    public async Task<ActionResult<Response>> SendEmailConfirmation
    (
        SendEmailConfirmationRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = request.ToCommand(CurrentUser.Id, request.Body.ConfirmationUrl);
        await Mediator.Send(command, cancellationToken);
        var response = new Response();

        return Ok(response);
    }

    [HttpPost("confirm-email")]
    public async Task<ActionResult<Response>> ConfirmEmail
    (
        ConfirmEmailChangingRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = request.ToCommand(CurrentUser.Id);
        await Mediator.Send(command, cancellationToken);
        var response = new Response();

        return Ok(response);
    }
}
