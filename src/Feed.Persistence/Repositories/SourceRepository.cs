using Feed.Application.Common.Pagination;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Publications.Entities;
using Feed.Persistence.Extensions;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class SourceRepository(FeedDbContext dbContext) : BaseRepository(dbContext), ISourceRepository
{
    public async Task AddAsync(Source source, CancellationToken cancellationToken)
    {
        await _dbContext
            .Sources
            .AddAsync(source.ToEntity(), cancellationToken);
    }

    public async Task<Source?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var sourceEntity = await _dbContext
            .Sources
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return sourceEntity?.ToDomain();
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
