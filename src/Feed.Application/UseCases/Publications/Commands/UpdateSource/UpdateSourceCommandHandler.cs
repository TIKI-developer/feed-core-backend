using Feed.Application.Exceptions;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Publications.Entities;
using Mediator;

namespace Feed.Application.UseCases.Publications.Commands.UpdateSource;

internal sealed class UpdateSourceCommandHandler
    (ISourceRepository sourceRepository)
    : ICommandHandler<UpdateSourceCommand>
{
    public async ValueTask<Unit> Handle(
        UpdateSourceCommand command,
        CancellationToken cancellationToken)
    {
        var source = await sourceRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Source), command.Id);

        source.Update(command.Name);
        await sourceRepository.UpdateAsync(source, cancellationToken);
        await sourceRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
