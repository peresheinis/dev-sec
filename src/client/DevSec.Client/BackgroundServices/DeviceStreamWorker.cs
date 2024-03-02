
using AForge.Video.DirectShow;

namespace DevSec.Client.BackgroundServices;

public class DeviceStreamWorker : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var index = 0;
        var captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        var videoCaptureDevice = new VideoCaptureDevice(captureDevices[1].MonikerString);

        //videoCaptureDevice.NewFrame += (_, e) => e.Frame.;
        videoCaptureDevice.Start();

        return Task.CompletedTask;
    }


}
