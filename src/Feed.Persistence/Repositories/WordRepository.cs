using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Dictionaries.Entities;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class WordRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IWordRepository
{
    public async Task AddAsync(Word word, CancellationToken cancellationToken = default)
    {
        var entity = word.ToEntity();

        await _dbContext.Words.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(ICollection<Word> words, CancellationToken cancellationToken = default)
    {
        var entities = words.Select(w => w.ToEntity()).ToList();

        await _dbContext.Words.AddRangeAsync(entities, cancellationToken);
    }

    public async Task<ICollection<Word>> GetByIdsAsync(ICollection<int> words, CancellationToken cancellationToken = default)
    {
        var wordEntities = await _dbContext
            .Words
            .Where(w => words.Contains(w.Id))
            .ToListAsync(cancellationToken);

        return [.. wordEntities.Select(w => w.ToDomain())];
    }

    public async Task<ICollection<Word>> GetByIdsTakeAsync(ICollection<int> words, int take, CancellationToken cancellationToken = default)
    {
        var wordEntities = await _dbContext
            .Words
            .Where(w => words.Contains(w.Id))
            .Take(take)
            .ToListAsync(cancellationToken);

        return [.. wordEntities.Select(w => w.ToDomain())];
    }

    public async Task<ICollection<Word>> GetByValuesAsync(ICollection<string> words, CancellationToken cancellationToken = default)
    {
        var wordEntities = await _dbContext
            .Words
            .Where(w => words.Contains(w.Value))
            .ToListAsync(cancellationToken);

        return [.. wordEntities.Select(w => w.ToDomain())];
    }
}
