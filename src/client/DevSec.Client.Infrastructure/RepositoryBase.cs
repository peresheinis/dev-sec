using DevSec.Client.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevSec.Client.Infrastructure;

public class RepositoryBase<T>(DbSet<T> set)
    where T : EntityBase
{
    public DbSet<T> Set { get; } = set;
}
