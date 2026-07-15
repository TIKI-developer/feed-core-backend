using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Users.Entities;
using Feed.Persistence.Mappings;

namespace Feed.Persistence.Repositories;

internal class RoleRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IRoleRepository
{
    public async Task AddAsync(Role newRole, CancellationToken cancellationToken)
    {
        await _dbContext
            .Roles
            .AddAsync(newRole.ToEntity(), cancellationToken);
    }
}
