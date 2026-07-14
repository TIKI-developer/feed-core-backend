using Feed.Domain.Dictionaries.Entities;
using Feed.Persistence.Entities;

namespace Feed.Persistence.Mappings;

internal static class WordMapping
{
    public static Word ToDomain(this WordEntity entity)
    {
        return Word.Restore(
            entity.Id,
            entity.Value
        );
    }

    public static WordEntity ToEntity(this Word word)
    {
        return new WordEntity
        {
            Id = word.Id,
            Value = word.Value
        };
    }
}
