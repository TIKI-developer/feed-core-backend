using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.DeleteDictionary;

public readonly record struct DeleteDictionaryCommand : ICommand
{
    public required Guid Id { get; init; }
}
