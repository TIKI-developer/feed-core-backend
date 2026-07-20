using Feed.Application.Exceptions;
using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Feed.Application.ViewModels;
using Feed.Domain.Publications.Entities;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetPublicationById;

internal sealed class GetPublicationByIdQueryHandler
    (IPublicationRepository publicationRepository)
    : IQueryHandler<GetPublicationByIdQuery, PublicationDetails>
{
    public async ValueTask<PublicationDetails> Handle(
        GetPublicationByIdQuery query,
        CancellationToken cancellationToken)
    {
        var publication = await publicationRepository.GetByIdAsync(query.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Publication), query.Id);

        return publication.ToDetails();
    }
}
