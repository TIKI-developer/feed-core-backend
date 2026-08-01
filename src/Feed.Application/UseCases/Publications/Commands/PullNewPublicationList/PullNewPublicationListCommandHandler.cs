using Feed.Application.Exceptions;
using Feed.Application.Interfaces;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Publications.Entities;
using Feed.Plugin.Abstractions;
using Mediator;

namespace Feed.Application.UseCases.Publications.Commands.PullNewPublicationList;

internal sealed class PullNewPublicationListCommandHandler
    (IPublicationRepository publicationRepository,
    ISourceRepository sourceRepository,
    ISourceProviderRegistry sourceProviderRegistry)
    : ICommandHandler<PullNewPublicationListCommand, PullNewPublicationListCommandResult>
{
    public async ValueTask<PullNewPublicationListCommandResult> Handle(
        PullNewPublicationListCommand command,
        CancellationToken cancellationToken)
    {
        var source = await sourceRepository.GetByIdAsync(command.SourceId, cancellationToken)
            ?? throw new NotFoundException(nameof(Source), command.SourceId);

        var sourceProvider = sourceProviderRegistry.Get(source.SourceProviderName)
            ?? throw new NotFoundException(nameof(ISourceProvider), source.SourceProviderName);

        var newPublicationDtos = await sourceProvider.GetNewPublicationAsync(source.ExternalId, source.LastCheckedAt);

        var newPublicationIds = new List<Guid>();

        foreach (var dto in newPublicationDtos)
        {
            var newPublication = Publication.Create(dto.ExternalId, dto.Body, source.Id, dto.PublishedAt);
            newPublicationIds.Add(newPublication.Id);

            await publicationRepository.AddAsync(newPublication, cancellationToken);
        }

        await publicationRepository.SaveChangesAsync(cancellationToken);

        return new()
        {
            NewPublicationIds = newPublicationIds
        };
    }
}