using Feed.Domain.Shared.ValueObjects;

namespace Feed.Persistence.Entities;

internal class DictionaryEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Timestamps Timestamps { get; internal set; }
    public ICollection<DictionaryWordEntity> DictionaryWords { get; set; } = [];
}
