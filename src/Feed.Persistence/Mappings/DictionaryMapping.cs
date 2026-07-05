using Feed.Domain.Dictionaries.Entities;
using Feed.Persistence.Entities;

namespace Feed.Persistence.Mappings;

internal static class DictionaryMapping
{
    public static DictionaryEntity ToEntity(this Dictionary dictionary)
    {
        return new DictionaryEntity
        {
            Id = dictionary.Id,
            Name = dictionary.Name,
            Timestamps = dictionary.Timestamps,
            DictionaryWords = [..dictionary.Words.Select(w => new DictionaryWordEntity
            {
                DictionaryId = dictionary.Id,
                WordId = w.Id,
            })],
        };
    }

    public static Dictionary ToDomain(this DictionaryEntity entity)
    {
        return Dictionary.Restore
        (
            entity.Id,
            entity.Name,
            [.. entity.DictionaryWords.Select(dw => new Word
            {
                Id = dw.WordId,
                Value = dw.Word.Value,
            })],
            entity.Timestamps
        );
    }
}
