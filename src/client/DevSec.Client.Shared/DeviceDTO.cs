namespace DevSec.Client.Shared;

/// <param name="Name"> Название устройства </param>
/// <param name="IsEnabled"> Флаг работы устройства. Если true, то устройство включено </param>
/// <param name="Color"> Цвет иконки устройства </param>
/// <param name="Location"> Локация устройства </param>
/// <param name="Sound"> Настройки управления звуков устройства </param>
/// <param name="Video"> Настройки управления видеокамерой устройства </param>
/// <param name="ConfigurationId"> Идентификатор конфигурации устройства </param>
/// <param name="Configuration"> Конфигурация устройства </param>
public sealed record DeviceDTO(
    string Name, 
    bool IsEnabled, 
    DeviceIconColorDTO? Color, 
    DeviceLocationDTO? Location, 
    DeviceSoundDTO? Sound, 
    DeviceVideoDTO Video, 
    Guid ConfigurationId,
    DeviceConfigurationDTO Configuration);