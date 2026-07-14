using Feed.Domain.Shared.ValueObjects;
using System.Collections.Generic;

namespace Feed.Persistence.Entities;

internal class DictionaryEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required Timestamps Timestamps { get; internal set; }

    // Навигация к таблице-связи многие-ко-многим
    internal ICollection<DictionaryWordEntity> DictionaryWords { get; set; } = new List<DictionaryWordEntity>();
}
