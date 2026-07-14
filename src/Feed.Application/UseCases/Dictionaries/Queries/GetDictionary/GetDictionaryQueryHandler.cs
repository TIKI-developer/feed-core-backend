using Feed.Application.Exceptions;
using Feed.Application.Interfaces.Repositories;
using Feed.Application.Mappings;
using Feed.Domain.Dictionaries.Entities;
using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Queries.GetDictionary;

internal sealed class GetDictionaryQueryHandler
    (IDictionaryRepository dictionaryRepository,
    IWordRepository wordRepository)
    : IQueryHandler<GetDictionaryQuery, GetDictionaryQueryResult>
{
    public async ValueTask<GetDictionaryQueryResult> Handle(
        GetDictionaryQuery query,
        CancellationToken cancellationToken)
    {
        var dictionary = await dictionaryRepository.GetByIdAsync(query.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Dictionary), query.Id);

        var words = await wordRepository.GetByIdsAsync([.. dictionary.Words], cancellationToken);

        return new GetDictionaryQueryResult
        {
            Dictionary = dictionary.ToDetails(words)
        };
    }
}
