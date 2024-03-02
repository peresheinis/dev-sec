using DevSec.Client.Core.Entities;
using Kernel.Shared.Extensions;

namespace DevSec.Client.Core.Repositories;

public interface IPagedRepositoryBase<TEntity>
    where TEntity : EntityBase
{ 
    public Task<PagedList<TEntity>> GetAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
