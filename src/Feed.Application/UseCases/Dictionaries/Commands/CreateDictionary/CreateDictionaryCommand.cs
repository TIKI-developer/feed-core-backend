using Feed.Application.UseCases.Dictionaries.Commands.CreateDictionary;
using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.CreateDictionar;

public readonly record struct CreateDictionaryCommand : ICommand<CreateDictionaryCommandResult>
{
    public required string Name { get; init; }
}