using Feed.Application.ViewModels;

namespace Feed.Application.UseCases.Dictionaries.Queries.GetDictionary;

public readonly record struct GetDictionaryQueryResult
{
    public required DictionaryDetails Dictionary { get; init; }
}
