using Feed.Application.UseCases.Dictionaries.Queries.GetDictionary;
using Feed.Application.UseCases.Users.Queries.GetDictionaries;
using Feed.WebApi.Interfaces;
using Feed.WebApi.Mappings;
using Feed.WebApi.Requests;
using Feed.WebApi.Responses;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Feed.WebApi.Controllers;

[Route("dictionaries")]
public class DictionaryController
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
    [HttpPost]
    public async Task<ActionResult<Response<CreateDictionaryResponse>>> Create
        (
            [FromBody] CreateDictionaryRequest request,
            CancellationToken cancellationToken
        )
    {
        var command = request.ToCommand();
        var result = await Mediator.Send(command, cancellationToken);
        var response = new Response<CreateDictionaryResponse>(result.ToResponse());

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<Response<GetDictionaryListQueryResult>>> Get
    (
        GetDictionaryListRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = request.ToQuery();
        var result = await Mediator.Send(command, cancellationToken);
        var response = new Response<GetDictionaryListQueryResult>(result);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response<GetDictionaryQueryResult>>> GetById
    (
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new GetDictionaryQuery { Id = id };
        var result = await Mediator.Send(command, cancellationToken);
        var response = new Response<GetDictionaryQueryResult>(result);

        return Ok(response);
    }

    [HttpPost("{id}/words/add")]
    public async Task<ActionResult<Response>> AddWords
    (
        Guid id,
        AddWordsToDictionaryRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = request.ToCommand(id);
        await Mediator.Send(command, cancellationToken);
        var response = new Response();

        return Ok(response);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Response>> Update
        (
            Guid id,
            UpdateDictionaryRequest request,
            CancellationToken cancellationToken
        )
    {
        var command = request.ToCommand(id);
        await Mediator.Send(command, cancellationToken);
        var response = new Response();

        return Ok(response);
    }
}
