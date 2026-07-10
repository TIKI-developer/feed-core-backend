using Feed.Domain.Dictionaries.Entities;

namespace Feed.Application.ViewModels;

public readonly record struct DictionaryItem
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required ICollection<string> FirstTenWords { get; init; } 
}
