using Feed.Application.Interfaces;
using Feed.Domain.Dictionaries.Entities;
using Feed.Persistence.Mappings;

namespace Feed.Persistence.Repositories;

internal class DictionaryRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IDictionaryRepository
{
    public async Task AddAsync(Dictionary dictionary, CancellationToken cancellationToken = default)
    {
        await _dbContext
            .Dictionaries
            .AddAsync(dictionary.ToEntity(), cancellationToken);
    }
}