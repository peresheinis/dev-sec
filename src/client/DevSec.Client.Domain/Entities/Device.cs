namespace DevSec.Client.Core.Entities;

public sealed class Device : EntityBase<Guid>
{
    private List<DeviceGroup> _groups;

    private Device() { }

    public Device(string name,
        DeviceVideo video,
        DeviceConfiguration configuration,
        DeviceIconColor? color = null,
        DeviceSound? sound = null,
        DeviceGroup? group = null,
        DeviceLocation? location = null)
    {
        _groups = new List<DeviceGroup>();
        
        if (configuration is null) throw new ArgumentNullException(nameof(configuration));
        if (video is null) throw new ArgumentNullException(nameof(video));
        if (color is null) throw new ArgumentNullException(nameof(color));
        if (group is not null) _groups.Add(group);

        Name = name;
        Video = video;
        Sound = sound;
        Color = color;
        Location = location;
        Configuration = configuration;
    }

    /// <summary>
    /// Название устройства
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Флаг работы устройства. Если true, то устройство включено
    /// </summary>
    public bool IsEnabled { get; private set; }

    /// <summary>
    /// Цвет иконки устройства
    /// </summary>
    public DeviceIconColor? Color { get; private set; }

    /// <summary>
    /// Группа с устройствами
    /// </summary>
    public IReadOnlyCollection<DeviceGroup>? Group => _groups;

    /// <summary>
    /// Локация устройства
    /// </summary>
    public DeviceLocation? Location { get; private set; }

    /// <summary>
    /// Настройки управления звуков устройства
    /// </summary>
    public DeviceSound? Sound { get; private set; }

    /// <summary>
    /// Настройки управления видеокамерой устройства
    /// </summary>
    public DeviceVideo Video { get; private set; }

    /// <summary>
    /// Идентификатор конфигурации устройства
    /// </summary>
    public Guid ConfigurationId { get; private set; }

    /// <summary>
    /// Конфигурация устройства
    /// </summary>
    public DeviceConfiguration Configuration { get; private set; }

    /// <summary>
    /// Включить / выключить трансляцию и запись устройства
    /// </summary>
    /// <param name="enabled"></param>
    public bool SetStatus(bool enabled)
    {
        var valueBeforeChanged = IsEnabled;

        IsEnabled = enabled;

        if (valueBeforeChanged != enabled)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Установить цвет иконки устройства
    /// </summary>
    /// <param name="deviceColor"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetColor(DeviceIconColor deviceColor)
    {
        if (deviceColor is null)
        {
            throw new ArgumentNullException(nameof(deviceColor));
        }

        Color = deviceColor;
    }
}
