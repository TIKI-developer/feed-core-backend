using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.UpdateDictionary;

public readonly record struct UpdateDictionaryCommand : ICommand
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}
