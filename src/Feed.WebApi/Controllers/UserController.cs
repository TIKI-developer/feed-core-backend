using Feed.Application.UseCases.Users.Queries.GetUser;
using Feed.Application.ViewModels;
using Feed.WebApi.Interfaces;
using Feed.WebApi.Responses;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<UserDetails>>> Get(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await Mediator.Send(query);
            var response = new Response<UserDetails>(result);

            return Ok(response);
        }
    }
}
