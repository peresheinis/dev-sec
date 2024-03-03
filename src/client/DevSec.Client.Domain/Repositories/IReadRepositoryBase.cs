using DevSec.Client.Core.Entities;

namespace DevSec.Client.Core.Repositories;

public interface IReadRepositoryBase<TEntity, TKey>
    where TEntity : EntityBase
    where TKey : IEquatable<TKey>
{
    public Task<TEntity?> GetByIdAsync(TKey key, CancellationToken cancellationToken = default);
}