using System.Collections.Generic;

namespace Feed.Persistence.Entities;

internal class WordEntity
{
    public int Id { get; set; }
    public required string Value { get; set; }

    // Навигация к таблице-связи многие-ко-многим
    internal ICollection<DictionaryWordEntity> DictionaryWords { get; set; } = new List<DictionaryWordEntity>();
}
