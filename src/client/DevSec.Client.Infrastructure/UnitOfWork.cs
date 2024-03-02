using DevSec.Client.Core;

namespace DevSec.Client.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _database;
    
    public UnitOfWork(DatabaseContext databaseContext)
    {
        _database = databaseContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _database.SaveChangesAsync(cancellationToken);
    }
}