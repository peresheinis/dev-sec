using Kernel.Shared.Exceptions;
using System.Net.NetworkInformation;

namespace DevSec.Client.Domain.Exceptions;

public class DeviceErrors
{
    public static AlertingException NotFound(Guid deviceId) =>
        AlertingException.NotFound("Устройство не найдено.", $"Устройство с идентификатором DeviceId = '{deviceId}' не существует.");

    public static AlertingException AlreadyEnabled(Guid deviceId) =>
        AlertingException.Conflict("Устройство уже включено.", $"Устройство с идентификатором DeviceId = '{deviceId}' уже включено.");

    public static AlertingException AlreadyDisabled(Guid deviceId) =>
        AlertingException.Conflict("Устройство уже выключено.", $"Устройство с идентификатором DeviceId = '{deviceId}' уже выключено.");
}
