using Feed.Application.Common.Pagination;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Dictionaries.Entities;
using Feed.Persistence.Extensions;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class DictionaryRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IDictionaryRepository
{
    public async Task AddAsync(Dictionary dictionary, CancellationToken cancellationToken = default)
    {
        await _dbContext
            .Dictionaries
            .AddAsync(dictionary.ToEntity(), cancellationToken);
    }

    public async Task<PagedList<Dictionary>> GetAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var dictionaryEntities = await _dbContext
            .Dictionaries
            .Select(e => e.ToDomain())
            .ToPagedListAsync(page, pageSize, cancellationToken);

        return dictionaryEntities;
    }
}
