using AForge.Video.DirectShow;
using DevSec.Client.Core.Repositories;

namespace DevSec.Client.Application.BackgroundServices;

public interface IDeviceRecordingManager
{
    public Task StartAsync(Guid DeviceId, CancellationToken cancellationToken = default);
    public Task StopAsync(Guid DeviceId, CancellationToken cancellationToken = default);
}

internal class DeviceRecordingManager(IDeviceRepository deviceRepository) : IDeviceRecordingManager
{
    private IDeviceRepository _deviceRepository = deviceRepository;

    public async Task StartAsync(Guid DeviceId, CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetByIdAsync(DeviceId, cancellationToken);

        var captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice)
            .Cast<FilterInfo>()
            .SingleOrDefault(x => x.MonikerString.Equals(device?.Video.Source.Moniker));

        if (captureDevice is null)
        {
            throw new InvalidOperationException("");
        }

        var videoSource = new VideoCaptureDevice(captureDevice.MonikerString);

        videoSource.NewFrame += (_, _) => Console.WriteLine("Frame");
        videoSource.Start();
    }

    public async Task StopAsync(Guid DeviceId, CancellationToken cancellationToken = default)
    {
        var device = await _deviceRepository.GetByIdAsync(DeviceId, cancellationToken);

        var captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice)
            .Cast<FilterInfo>()
            .SingleOrDefault(x => x.MonikerString.Equals(device?.Video.Source.Moniker));

        if (captureDevice is null)
        {
            throw new InvalidOperationException("");
        }

        var videoSource = new VideoCaptureDevice(captureDevice.MonikerString);

        videoSource.SignalToStop();
    }
}
