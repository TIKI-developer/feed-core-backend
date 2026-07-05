using Feed.Persistence.Interfaces;

namespace Feed.Persistence;

internal class DbInitializer(FeedDbContext dbContext) : IDbInitializer
{
    private readonly FeedDbContext _dbContext = dbContext;

    public async Task InitializeAsync()
    {
        var retries = 10;
        var delay = TimeSpan.FromSeconds(2);

        for (int i = 0; i < retries; i++)
        {
            try
            {
                await _dbContext.Database.EnsureDeletedAsync();
                await _dbContext.Database.EnsureCreatedAsync();
                return;
            }
            catch
            {
                Console.WriteLine($"DB not ready, retry {i + 1}/{retries}");

                if (i == retries - 1)
                    throw;

                await Task.Delay(delay);
            }
        }
    }
}
