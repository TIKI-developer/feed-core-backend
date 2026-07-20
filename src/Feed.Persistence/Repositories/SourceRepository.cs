using Feed.Application.Common.Pagination;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Publications.Entities;
using Feed.Persistence.Extensions;
using Feed.Persistence.Mappings;

namespace Feed.Persistence.Repositories;

internal class SourceRepository(FeedDbContext dbContext) : BaseRepository(dbContext), ISourceRepository
{
    public async Task AddAsync(Source source, CancellationToken cancellationToken)
    {
        await _dbContext
            .Sources
            .AddAsync(source.ToEntity(), cancellationToken);
    }

    public async Task<PagedList<Source>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        var sourceEntities = await _dbContext
            .Sources
            .Select(e => e.ToDomain())
            .ToPagedListAsync(page, pageSize, cancellationToken);

        return sourceEntities;
    }
}
