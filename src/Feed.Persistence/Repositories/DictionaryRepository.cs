using Feed.Application.Common.Pagination;
using Feed.Application.Interfaces.Repositories;
using Feed.Domain.Dictionaries.Entities;
using Feed.Persistence.Entities;
using Feed.Persistence.Extensions;
using Feed.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence.Repositories;

internal class DictionaryRepository(FeedDbContext dbContext) : BaseRepository(dbContext), IDictionaryRepository
{
    public async Task AddAsync(
        Dictionary dictionary,
        CancellationToken cancellationToken = default)
    {
        await _dbContext
            .Dictionaries
            .AddAsync(dictionary.ToEntity(), cancellationToken);
    }

    public async Task<PagedList<Dictionary>> GetPagedListAsync(
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var dictionaryEntities = await _dbContext
            .Dictionaries
            .Include(e => e.Timestamps)
            .Include(e => e.DictionaryWords)
            .Select(e => e.ToDomain())
            .ToPagedListAsync(page, pageSize, cancellationToken);

        return dictionaryEntities;
    }

    public async Task<Dictionary?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var dictionaryEntity = await _dbContext
            .Dictionaries
            .Include(e => e.DictionaryWords)
            .Include(e => e.Timestamps)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return dictionaryEntity?.ToDomain();
    }

    public async Task UpdateAsync(Dictionary dictionary, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Dictionaries
            .Include(d => d.DictionaryWords)
            .FirstOrDefaultAsync(d => d.Id == dictionary.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Dictionary {dictionary.Id} not found");

        entity.Name = dictionary.Name;
        entity.Timestamps = dictionary.Timestamps;

        var currentWordIds = entity.DictionaryWords.Select(dw => dw.WordId).ToHashSet();
        var desiredWordIds = dictionary.Words;

        var toAdd = desiredWordIds.Except(currentWordIds).ToList();
        foreach (var wid in toAdd)
        {
            entity.DictionaryWords.Add(new DictionaryWordEntity
            {
                DictionaryId = entity.Id,
                WordId = wid
            });
        }

        var toRemove = currentWordIds.Except(desiredWordIds).ToList();
        foreach (var wid in toRemove)
        {
            var rel = entity.DictionaryWords.FirstOrDefault(dw => dw.WordId == wid);
            if (rel != null)
                entity.DictionaryWords.Remove(rel);
        }
    }
}
