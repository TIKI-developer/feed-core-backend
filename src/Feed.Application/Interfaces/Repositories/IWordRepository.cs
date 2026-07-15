using Feed.Domain.Dictionaries.Entities;

namespace Feed.Application.Interfaces.Repositories;

public interface IWordRepository : IBaseRepository
{
    Task<ICollection<Word>> GetByIdsAsync(ICollection<int> words, CancellationToken cancellationToken = default);
    Task<ICollection<Word>> GetByIdsTakeAsync(ICollection<int> words, int take, CancellationToken cancellationToken = default);
    Task<ICollection<Word>> GetByValuesAsync(ICollection<string> words, CancellationToken cancellationToken = default);
    Task AddAsync(Word word, CancellationToken cancellationToken = default);
    Task AddRangeAsync(ICollection<Word> words, CancellationToken cancellationToken = default);
}
