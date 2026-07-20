using Feed.Application.Common.Pagination;
using Feed.Domain.Publications.Entities;

namespace Feed.Application.Interfaces.Repositories;

public interface IPublicationRepository : IBaseRepository
{
    Task<Publication?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedList<Publication>> GetPagedListAsync(int page, int pageSize, CancellationToken cancellationToken);
}
