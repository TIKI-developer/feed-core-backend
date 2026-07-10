using Feed.Application.Common.Pagination;
using Feed.Application.ViewModels;

namespace Feed.Application.UseCases.Users.Queries.GetDictionaries;

public readonly record struct GetDictionaryListQueryResult
{
    public required PagedList<DictionaryItem> Dictionaries { get; init; }
}
