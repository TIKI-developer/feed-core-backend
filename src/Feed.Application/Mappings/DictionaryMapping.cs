using Feed.Application.ViewModels;
using Feed.Domain.Dictionaries.Entities;

namespace Feed.Application.Mappings;

internal static class DictionaryMapping
{
    public static DictionaryItem ToItem(this Dictionary dictionary, ICollection<Word> firstTenWords)
    {
        return new DictionaryItem
        {
            Id = dictionary.Id,
            Name = dictionary.Name,
            FirstTenWords = [.. firstTenWords.Select(w => w.Value)],
        };
    }

    public static DictionaryDetails ToDetails(this Dictionary dictionary, ICollection<Word> words)
    {
        return new DictionaryDetails
        {
            Id = dictionary.Id,
            Name = dictionary.Name,
            Words = words,
            Timestamps = dictionary.Timestamps
        };
    }
}
