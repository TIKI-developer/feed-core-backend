using Feed.Application.Exceptions;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Dictionaries.Entities;
using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.DeleteDictionary;

internal sealed class DeleteDictionaryCommandHandler
    (IDictionaryRepository dictionaryRepository)
    : ICommandHandler<DeleteDictionaryCommand>
{
    public async ValueTask<Unit> Handle(
        DeleteDictionaryCommand command,
        CancellationToken cancellationToken)
    {
        var dictionary = await dictionaryRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Dictionary), command.Id);

        await dictionaryRepository.DeleteAsync(dictionary, cancellationToken);
        await dictionaryRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}