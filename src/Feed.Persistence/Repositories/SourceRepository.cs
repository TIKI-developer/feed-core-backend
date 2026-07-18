using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Publications.Entities;
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
}
