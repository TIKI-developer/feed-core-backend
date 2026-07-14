using System.Collections.Generic;
using System.Linq;
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
            DictionaryWords = dictionary.Words
                .Select(wid => new DictionaryWordEntity
                {
                    DictionaryId = dictionary.Id,
                    WordId = wid
                })
                .ToList()
        };
    }

    public static Dictionary ToDomain(this DictionaryEntity entity)
    {
        var wordIds = entity.DictionaryWords?.Select(dw => dw.WordId).ToList() ?? new List<int>();

        return Dictionary.Restore(
            entity.Id,
            entity.Name,
            wordIds,
            entity.Timestamps
        );
    }
}
