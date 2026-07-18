using Feed.Application.Interfaces;
using Feed.Application.Mappings;
using Mediator;

namespace Feed.Application.UseCases.Publications.Query.GetSourceProviderList;

internal sealed class GetSourceProviderListQueryHandler
    (ISourceProviderRegistry sourceProviderRepository)
    : IQueryHandler<GetSourceProviderListQuery, GetSourceProviderListQueryResult>
{
    public async ValueTask<GetSourceProviderListQueryResult> Handle(
        GetSourceProviderListQuery query,
        CancellationToken cancellationToken)
    {
        var sourceProviders = sourceProviderRepository.GetAll();

        return new GetSourceProviderListQueryResult
        {
            SourceProviders = [.. sourceProviders.Select(sp => sp.ToItem())]
        };
    }
}
