using Feed.Domain.Dictionaries.Entities;
using Feed.Domain.Shared.ValueObjects;

namespace Feed.Application.ViewModels;

public readonly record struct DictionaryDetails
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required IReadOnlyCollection<Word> Words { get; init; }
    public required Timestamps Timestamps { get; init; }
}
