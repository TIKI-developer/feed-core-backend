namespace Feed.Persistence.Repositories;

public class BaseRepository(FeedDbContext dbContext)
{
    protected readonly FeedDbContext _dbContext = dbContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
