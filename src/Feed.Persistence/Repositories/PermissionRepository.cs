using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Users.ValueObjects;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class PermissionRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IPermissionRepository
{
    public async Task<ICollection<Permission>> GetAsync(CancellationToken cancellationToken)
    {
        return await _dbContext
            .Permissions
            .Select(e => e.ToDomain())
            .ToListAsync(cancellationToken);
    }
}
