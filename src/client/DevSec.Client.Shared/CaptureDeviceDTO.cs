namespace DevSec.Client.Shared;

/// <summary>
/// Устройство подключенное к компьютеру
/// </summary>
/// <param name="Name">Название устройства</param>
/// <param name="Moniker">Полное физическое название устройства</param>
public sealed record CaptureDeviceDTO(
    string Name, 
    string Moniker);