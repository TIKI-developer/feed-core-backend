using Feed.Application.Common.Pagination;
using Feed.Application.UseCases.Publications.Query.GetPublicationById;
using Feed.Application.ViewModels;
using Feed.WebApi.Interfaces;
using Feed.WebApi.Mappings;
using Feed.WebApi.Requests;
using Feed.WebApi.Responses;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

[Route("publications")]
public class PublicationController
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
    public async Task<ActionResult<Response<PagedList<PublicationItem>>>> Get
    (
        GetPublicationListRequest request,
        CancellationToken cancellationToken
    )
    {
        var query = request.ToQuery();
        var result = await Mediator.Send(query, cancellationToken);
        var response = new Response<PagedList<PublicationItem>>(result);

        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Response<PublicationDetails>>> GetById
    (
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetPublicationByIdQuery { Id = id };
        var result = await Mediator.Send(query, cancellationToken);
        var response = new Response<PublicationDetails>(result);

        return Ok(response);
    }
}
