using DevSec.Client.Core.Entities;

namespace DevSec.Client.Core.Repositories;

public interface IWriteRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    public void Remove(TEntity entity);
    public void Update(TEntity entity);
}