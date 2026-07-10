using Feed.WebApi.Interfaces;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

public class BaseController(IMediator mediator, ICurrentUser currentUser) : ControllerBase
{
    protected IMediator Mediator { get; private set; } = mediator;
    protected ICurrentUser CurrentUser => currentUser;
}
