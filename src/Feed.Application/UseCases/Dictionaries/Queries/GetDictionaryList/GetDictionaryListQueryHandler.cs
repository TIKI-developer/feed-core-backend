using Feed.Application.Common.Pagination;
using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Feed.Application.UseCases.Users.Queries.GetDictionaries;
using Feed.Application.ViewModels;
using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Queries.GetDictionaryList;

internal sealed class GetDictionaryListQueryHandler
    (IDictionaryRepository dictionaryRepository,
    IWordRepository wordRepository)
    : IQueryHandler<GetDictionaryListQuery, GetDictionaryListQueryResult>
{
    public async ValueTask<GetDictionaryListQueryResult> Handle(
        GetDictionaryListQuery query,
        CancellationToken cancellationToken)
    {
        var dictionariesPagedList = await dictionaryRepository
            .GetPagedListAsync
                (
                    query.Pagination.Page,
                    query.Pagination.PageSize,
                    cancellationToken
                );

        var dictionaryItems = new List<DictionaryItem>();
        int takeFitst = 10;

        foreach (var dictionary in dictionariesPagedList.Items)
        {
            var dictionaryWords = await wordRepository
                .GetByIdsTakeAsync([.. dictionary.Words], takeFitst, cancellationToken);

            dictionaryItems.Add(dictionary.ToItem(dictionaryWords));
        }

        return new()
        {
            Dictionaries = new PagedList<DictionaryItem>
            (
                dictionaryItems,
                dictionariesPagedList.Page,
                dictionariesPagedList.PageSize,
                dictionariesPagedList.TotalCount
            )
        };
    }
}
