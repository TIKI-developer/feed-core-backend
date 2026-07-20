using Feed.Application.Common.Pagination;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Publications.Entities;
using Feed.Persistence.Extensions;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class PublicationRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IPublicationRepository
{
    public async Task<PagedList<Publication>> GetPagedListAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        var publicationEntities = await _dbContext
            .Publications
            .Select(e => e.ToDomain())
            .AsNoTracking()
            .ToPagedListAsync(page, pageSize, cancellationToken);

        return publicationEntities;
    }
}
