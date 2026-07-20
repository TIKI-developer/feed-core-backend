using Feed.Application.UseCases.Publications.Commands.UpdateSource;
using Feed.Application.UseCases.Publications.Query.GetSourceById;
using Feed.Application.UseCases.Publications.Query.GetSourceList;
using Feed.Application.UseCases.Publications.Query.GetSourceProviderList;
using Feed.Application.ViewModels;
using Feed.WebApi.Interfaces;
using Feed.WebApi.Mappings;
using Feed.WebApi.Requests;
using Feed.WebApi.Responses;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

[Route("sources")]
public class SourceController
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
    [HttpGet("providers")]
    public async Task<ActionResult<Response<GetSourceProviderListQueryResult>>> GetSourceProvders
    (
        CancellationToken cancellationToken
    )
    {
        var query = new GetSourceProviderListQuery();
        var result = await Mediator.Send(query, cancellationToken);
        var response = new Response<GetSourceProviderListQueryResult>(result);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response>> CreateSource
    (
        CreateSourceRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = request.ToCommand();
        var result = await Mediator.Send(command, cancellationToken);
        var response = new Response<CreateSourceResponse>(result.ToResponse());

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<Response<GetSourceListQueryResult>>> Get
    (
        GetSourceListRequest request,
        CancellationToken cancellationToken
    )
    {
        var query = request.ToQuery();
        var result = await Mediator.Send(query, cancellationToken);
        var response = new Response<GetSourceListQueryResult>(result);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response<SourceDetails>>> GetById
    (
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var query = new GetSourceByIdQuery { Id = id };
        var result = await Mediator.Send(query, cancellationToken);
        var response = new Response<SourceDetails>(result);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Response>> Update
    (
        Guid id,
        UpdateSourceRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = request.ToCommand(id);
        await Mediator.Send(command, cancellationToken);
        var response = new Response();

        return Ok(response);
    }
}
