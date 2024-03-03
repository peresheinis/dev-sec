using DevSec.Client.Core.Entities;

namespace DevSec.Client.Core.Repositories;

public interface IDeviceReadRepository : IReadRepositoryBase<Device, Guid>, IPagedRepositoryBase<Device>
{ 

}
