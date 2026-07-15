using Feed.Application.UseCases.Users.Queries.GetUser;
using Feed.Application.UseCases.Users.Queries.GetUserList;
using Feed.Application.ViewModels;
using Feed.WebApi.Interfaces;
using Feed.WebApi.Mappings;
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
        [HttpGet]
        public async Task<ActionResult<Response<UserDetails>>> Get()
        {
            var query = new GetUserListQuery();
            var result = await Mediator.Send(query);
            var response = new Response<GetUserListResponse>(result.ToResponse());

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<UserDetails>>> GetById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await Mediator.Send(query);
            var response = new Response<UserDetails>(result);

            return Ok(response);
        }
    }
}
