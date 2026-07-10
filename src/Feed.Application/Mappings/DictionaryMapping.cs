using Feed.Application.ViewModels;
using Feed.Domain.Dictionaries.Entities;

namespace Feed.Application.Mappings;

internal static class DictionaryMapping
{
    public static DictionaryItem ToItem(this Dictionary dictionary)
    {
        return new DictionaryItem
        {
            Id = dictionary.Id,
            Name = dictionary.Name,
            FirstTenWords = [.. dictionary.Words.Take(10).Select(w => w.Value)]
        };
    }
}
