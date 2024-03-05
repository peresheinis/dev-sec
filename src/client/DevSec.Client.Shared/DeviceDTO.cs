namespace DevSec.Client.Shared;

public class DeviceDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsEnabled { get; set; }
    public DeviceIconColorDTO? Color { get; set; }
    public DeviceLocationDTO? Location { get; set; }
    public DeviceSoundDTO? Sound { get; set; }
    public DeviceVideoDTO Video { get; set; }
    public Guid ConfigurationId { get; set; }
    public DeviceConfigurationDTO Configuration { get; set; }
};