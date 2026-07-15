using Feed.Application.Common.Pagination;
using Feed.Domain.Dictionaries.Entities;

namespace Feed.Application.Interfaces.Repositories;

public interface IDictionaryRepository : IBaseRepository
{
    Task AddAsync(Dictionary dictionary, CancellationToken cancellationToken = default);
    Task<PagedList<Dictionary>> GetAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<Dictionary?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(Dictionary dictionary, CancellationToken cancellationToken);
}
