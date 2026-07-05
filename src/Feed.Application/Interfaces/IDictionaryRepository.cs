using Feed.Domain.Dictionaries.Entities;

namespace Feed.Application.Interfaces;

public interface IDictionaryRepository : IBaseRepository
{
    Task AddAsync(Dictionary dictionary, CancellationToken cancellationToken = default);
}