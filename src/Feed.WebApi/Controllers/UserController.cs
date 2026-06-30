using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

[Route("users")]
public class UserController
    (
        IMediator mediator
    )
    :
    BaseController
    (
        mediator
    )
{

    //[HttpGet("{id}")]
    //public async Task<ActionResult<UserItem>> GetUser
    //    (
    //        [FromRoute] Guid id,
    //        CancellationToken cancellationToken
    //    )
    //{
    //    var query = new GetUserQuery { Id = id };
    //    var result = await Mediator.Send(query, cancellationToken);

    //    return Ok(result);
    //}


}