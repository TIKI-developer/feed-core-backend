namespace Feed.Application.UseCases.Dictionaries.Commands.CreateDictionary;

public readonly record struct CreateDictionaryCommandResult
{
    public required Guid Id { get; init; }
}
