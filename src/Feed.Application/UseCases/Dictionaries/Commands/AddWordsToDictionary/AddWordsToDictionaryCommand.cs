using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.AddWordsToDictionary;

public readonly record struct AddWordsToDictionaryCommand : ICommand
{
    public required Guid DictionaryId { get; init; }
    public required ICollection<string> Words { get; init; }
}
