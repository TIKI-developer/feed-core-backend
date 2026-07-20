using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Publications.Entities;
using Mediator;

namespace Feed.Application.UseCases.Publications.Commands.CreateSource;

internal sealed class CreateSourceCommandHandler
    (ISourceRepository sourceRepository)
    : ICommandHandler<CreateSourceCommand, CreateSourceCommandResult>
{
    public async ValueTask<CreateSourceCommandResult> Handle(
        CreateSourceCommand command,
        CancellationToken cancellationToken)
    {
        var newSource = Source.Create(command.Name, command.ExternalId, command.SourceProviderName);

        await sourceRepository.AddAsync(newSource, cancellationToken);
        await sourceRepository.SaveChangesAsync(cancellationToken);

        return new CreateSourceCommandResult
        {
            Id = newSource.Id,
        };
    }
}
