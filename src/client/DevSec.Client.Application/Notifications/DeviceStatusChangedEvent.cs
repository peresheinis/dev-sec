using MediatR;

namespace DevSec.Client.Application.Notifications;

/// <summary>
/// Оповещение о включении / выключении устройства
/// </summary>
/// <param name="Id"></param>
/// <param name="IsEnabled"></param>
public record DeviceStatusChangedEvent(Guid Id, bool IsEnabled) : INotification;