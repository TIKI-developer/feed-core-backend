using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.RemoveWordsFromDictionary;

public readonly record struct RemoveWordsFromDictionaryCommand : ICommand
{
    public required Guid DictionaryId { get; init; }
    public required ICollection<string> Words { get; init; }
}
