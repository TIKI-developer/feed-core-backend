using Feed.Application.Interfaces;
using Feed.Domain.Users.Entities;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class UserRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IUserRepository
{
    public async Task AddAsync
        (
            User user,
            CancellationToken cancellationToken = default
        )
    {
        await _dbContext
                .Users
                .AddAsync(user.ToEntity(), cancellationToken);
    }

    public async Task<ICollection<User>> GetAsync
        (
            CancellationToken cancellationToken = default
        )
    {
        var userEntities = await _dbContext
                                    .Users
                                    .AsNoTracking()
                                    .ToListAsync(cancellationToken);

        return [.. userEntities.Select(e => e.ToDomain())];
    }

    public async Task<User?> GetByIdAsync
    (
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var userEntity = await _dbContext
                                    .Users
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        return userEntity?.ToDomain();
    }

    public async Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var userEntity = await _dbContext
                                    .Users
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(u => u.Name == name, cancellationToken);

        return userEntity?.ToDomain();
    }
}
