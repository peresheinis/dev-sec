using DevSec.Client.Application.BackgroundServices;
using MediatR;

namespace DevSec.Client.Application.Notifications;

internal class DeviceStatusChangedEventHandler(IDeviceRecordingManager deviceRecordingManager) : INotificationHandler<DeviceStatusChangedEvent>
{
    private readonly IDeviceRecordingManager _deviceRecordingManager = deviceRecordingManager;

    public Task Handle(DeviceStatusChangedEvent notification, CancellationToken cancellationToken)
    {
        if (notification.IsEnabled)
        {
            return _deviceRecordingManager.StartAsync(notification.Id);
        }

        return _deviceRecordingManager.StopAsync(notification.Id);
    }
}
