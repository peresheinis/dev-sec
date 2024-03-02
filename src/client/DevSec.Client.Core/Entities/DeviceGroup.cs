namespace DevSec.Client.Core.Entities;

public sealed class DeviceGroup : EntityBase<Guid>
{ 
    private List<Device> _devices;

    public DeviceGroup()
    {
        _devices = new List<Device>();
    }

    public IReadOnlyCollection<Device> Devices => _devices;

    public void AddDevice(Device device) => _devices.Add(device);

    public void RemoveDevice(Device device) => _devices.Remove(device);
}
