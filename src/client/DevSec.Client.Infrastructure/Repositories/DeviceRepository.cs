using DevSec.Client.Core.Entities;
using DevSec.Client.Core.Repositories;
using DevSec.Client.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace DevSec.Client.Infrastructure.Repositories;

public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
{
    public DeviceRepository(DatabaseContext databaseContext) : base(databaseContext.Devices) { }

    public async Task AddAsync(Device entity, CancellationToken cancellationToken = default) => 
        await Set.AddAsync(entity, cancellationToken);

    public async Task<IPagedList<Device>> GetAsync(int page, int pageSize, CancellationToken cancellationToken = default) =>
        await Set.ToPagedListAsync(page, pageSize, cancellationToken);

    public async Task<Device?> GetByIdAsync(Guid key, CancellationToken cancellationToken = default) =>
        await Set.SingleOrDefaultAsync(e => e.Id.Equals(key));

    public void Remove(Device entity) =>
        Set.Remove(entity);

    public void Update(Device entity) =>
        Set.Update(entity);
}
