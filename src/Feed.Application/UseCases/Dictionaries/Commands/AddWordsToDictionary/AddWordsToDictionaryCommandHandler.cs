using Feed.Application.Exceptions;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Dictionaries.Entities;
using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.AddWordsToDictionary;

internal sealed class AddWordsToDictionaryCommandHandler
    (IDictionaryRepository dictionaryRepository,
    IWordRepository wordRepository)
    : ICommandHandler<AddWordsToDictionaryCommand>
{
    public async ValueTask<Unit> Handle(
        AddWordsToDictionaryCommand command,
        CancellationToken cancellationToken)
    {
        var dictionary = await dictionaryRepository.GetByIdAsync(
            command.DictionaryId,
            cancellationToken)
            ?? throw new NotFoundException(nameof(Dictionary), command.DictionaryId);

        var existingWords = await wordRepository.GetByValuesAsync(
            command.Words,
            cancellationToken);

        var existingValues = existingWords
            .Select(x => x.Value)
            .ToHashSet();

        var createdWords = command.Words
            .Where(x => !existingValues.Contains(x))
            .Select(Word.Create)
            .ToList();

        await wordRepository.AddRangeAsync(createdWords, cancellationToken);
        await wordRepository.SaveChangesAsync(cancellationToken);

        var allWords = (await wordRepository.GetByValuesAsync(command.Words, cancellationToken))
            .ToList();

        dictionary.AddWords(allWords.Select(e => e.Id));
        await dictionaryRepository.UpdateAsync(dictionary, cancellationToken);

        await wordRepository.SaveChangesAsync(cancellationToken);
        await dictionaryRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
