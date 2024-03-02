using AForge.Video.DirectShow;

namespace DevSec.Client.Services;

public interface IVideoCaptureDevices
{
    public IReadOnlyCollection<FilterInfo> GetVideoDevices();
}

public interface ISoundCaptureDevices
{
    public IReadOnlyCollection<FilterInfo> GetSoundDevices();
}

public interface IDevicesService : IVideoCaptureDevices, ISoundCaptureDevices { }

public sealed class DevicesService : IDevicesService
{
    public IReadOnlyCollection<FilterInfo> GetSoundDevices()
    {
        return new FilterInfoCollection(FilterCategory.AudioInputDevice)
           .Cast<FilterInfo>()
           .ToList();
    }

    public IReadOnlyCollection<FilterInfo> GetVideoDevices()
    {
        return new FilterInfoCollection(FilterCategory.VideoInputDevice)
            .Cast<FilterInfo>()
            .ToList();
    }
}
