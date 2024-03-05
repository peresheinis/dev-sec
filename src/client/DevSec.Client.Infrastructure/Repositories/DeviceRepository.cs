using DevSec.Client.Core.Entities;
using DevSec.Client.Core.Repositories;
using Kernel.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DevSec.Client.Infrastructure.Repositories;

public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
{
    public DeviceRepository(DatabaseContext databaseContext) : base(databaseContext.Devices) { }

    public async Task AddAsync(Device entity, CancellationToken cancellationToken = default) => 
        await Set.AddAsync(entity, cancellationToken);

    public async Task<PagedList<Device>> GetAsync(int page, int pageSize, CancellationToken cancellationToken = default) =>
        await Set.ToPagedListAsync(page, pageSize, cancellationToken);

    public async Task<Device?> GetByIdAsync(Guid key, CancellationToken cancellationToken = default) =>
        await Set
            .Include(x => x.Configuration)
            .Include(x => x.Sound)
            .Include(x => x.Video)
            .SingleOrDefaultAsync(e => e.Id.Equals(key));

    public void Remove(Device entity) =>
        Set.Remove(entity);

    public void Update(Device entity) =>
        Set.Update(entity);
}
