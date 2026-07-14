using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Users.Entities;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class UserTokenRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IUserTokenRepository
{
    public async Task AddAsync(
        UserToken token,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.ConfirmationTokens.AddAsync(token.ToEntity(), cancellationToken);
    }

    public async Task<UserToken?> GetByTokenHashAsync(
        byte[] tokenHash,
        CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext
            .ConfirmationTokens
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TokenHash == tokenHash, cancellationToken);

        return entity?.ToDomain();
    }
}
