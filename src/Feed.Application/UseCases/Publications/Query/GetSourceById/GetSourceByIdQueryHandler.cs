using Feed.Application.Exceptions;
using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Feed.Application.ViewModels;
using Feed.Domain.Publications.Entities;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetSourceById;

internal sealed class GetSourceByIdQueryHandler
    (ISourceRepository sourceRepository)
    : IQueryHandler<GetSourceByIdQuery, SourceDetails>
{
    public async ValueTask<SourceDetails> Handle(
        GetSourceByIdQuery query,
        CancellationToken cancellationToken)
    {
        var source = await sourceRepository.GetByIdAsync(query.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Source), query.Id);

        return source.ToDetails();
    }
}
