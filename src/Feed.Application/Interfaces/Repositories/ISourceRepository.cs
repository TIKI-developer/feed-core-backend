using Feed.Application.Common.Pagination;
using Feed.Domain.Publications.Entities;

namespace Feed.Application.Interfaces.Repositories;

public interface ISourceRepository : IBaseRepository
{
    Task AddAsync(Source newSource, CancellationToken cancellationToken);
    Task<Source?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedList<Source>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken);
    Task UpdateAsync(Source source, CancellationToken cancellationToken);
}
