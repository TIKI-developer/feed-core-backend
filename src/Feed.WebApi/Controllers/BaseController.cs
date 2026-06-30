using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

public class BaseController(IMediator mediator) : ControllerBase
{
    protected IMediator Mediator { get; private set; } = mediator;
}
