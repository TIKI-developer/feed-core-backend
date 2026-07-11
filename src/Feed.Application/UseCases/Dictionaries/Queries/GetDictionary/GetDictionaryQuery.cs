using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Queries.GetDictionary;

public readonly record struct GetDictionaryQuery : IQuery<GetDictionaryQueryResult>
{
    public required Guid Id { get; init; }
}
