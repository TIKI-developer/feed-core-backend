using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Users.Entities;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class RoleRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IRoleRepository
{
    public async Task AddAsync(Role newRole, CancellationToken cancellationToken)
    {
        await _dbContext
            .Roles
            .AddAsync(newRole.ToEntity(), cancellationToken);
    }

    public async Task<ICollection<Role>> GetAsync(CancellationToken cancellationToken)
    {
        return await _dbContext
            .Roles
            .Include(e => e.Permissions)
            .Select(e => e.ToDomain())
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
