using Feed.Application.Exceptions;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Dictionaries.Entities;
using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.RemoveWordsFromDictionary;

internal sealed class RemoveWordsFromDictionaryCommandHandler
    (IDictionaryRepository dictionaryRepository,
    IWordRepository wordRepository)
    : ICommandHandler<RemoveWordsFromDictionaryCommand>
{
    public async ValueTask<Unit> Handle(
        RemoveWordsFromDictionaryCommand command,
        CancellationToken cancellationToken)
    {
        var dictionary = await dictionaryRepository.GetByIdAsync(command.DictionaryId, cancellationToken)
            ?? throw new NotFoundException(nameof(Dictionary), command.DictionaryId);
        var words = await wordRepository.GetByValuesAsync(command.Words, cancellationToken);
        dictionary.RemoveWords(words.Select(e => e.Id));
        await dictionaryRepository.UpdateAsync(dictionary, cancellationToken);
        await dictionaryRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
