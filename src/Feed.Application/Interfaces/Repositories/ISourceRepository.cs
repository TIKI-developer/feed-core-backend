using Feed.Domain.Publications.Entities;

namespace Feed.Application.Interfaces.Repositories;

public interface ISourceRepository : IBaseRepository
{
    Task AddAsync(Source newSource, CancellationToken cancellationToken);
}
