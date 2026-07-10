using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Mediator;

namespace Feed.Application.UseCases.Users.Queries.GetDictionaries;

internal sealed class GetDictionaryListQueryHandler
    (IDictionaryRepository dictionaryRepository)
    : IQueryHandler<GetDictionaryListQuery, GetDictionaryListQueryResult>
{
    public async ValueTask<GetDictionaryListQueryResult> Handle(
        GetDictionaryListQuery query,
        CancellationToken cancellationToken)
    {
        var dictionaries = await dictionaryRepository
            .GetAsync
                (
                    query.Pagination.Page,
                    query.Pagination.PageSize,
                    cancellationToken
                );

        return new()
        {
            Dictionaries = dictionaries.Select(d => d.ToItem())
        };
    }
}
