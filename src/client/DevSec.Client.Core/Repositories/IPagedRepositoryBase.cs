using DevSec.Client.Core.Entities;
using PagedList;

namespace DevSec.Client.Core.Repositories;

public interface IPagedRepositoryBase<TEntity>
    where TEntity : EntityBase
{ 
    public Task<IPagedList<TEntity>> GetAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
