using Feed.Application.Exceptions;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Dictionaries.Entities;
using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.UpdateDictionary;

internal sealed class UpdateDictionaryCommandHandler
    (IDictionaryRepository dictionaryRepository)
    : ICommandHandler<UpdateDictionaryCommand>
{
    public async ValueTask<Unit> Handle(
        UpdateDictionaryCommand command,
        CancellationToken cancellationToken)
    {
        var dictionary = await dictionaryRepository.GetByIdAsync(command.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Dictionary), command.Id);

        dictionary.Update(command.Name);

        await dictionaryRepository.UpdateAsync(dictionary, cancellationToken);
        await dictionaryRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
