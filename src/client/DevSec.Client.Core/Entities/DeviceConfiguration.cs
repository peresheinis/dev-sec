namespace DevSec.Client.Core.Entities;

public sealed class DeviceConfiguration : EntityBase<Guid>
{
    private DeviceConfiguration() { }

    public DeviceConfiguration(bool isCompressEnabled, bool isNotificatiosEnabled, bool isMotionRecognitionEnabled)
    {
        IsCompressEnabled = isCompressEnabled;
        IsNotificationsEnabled = isNotificatiosEnabled;
        IsMotionRecognitionEnabled = isMotionRecognitionEnabled;
    }

    /// <summary>
    /// Включено ли сжатие для кадров изображения
    /// </summary>
    public bool IsCompressEnabled { get; private set; }

    /// <summary>
    /// Включены ли оповещения о событиях на камере
    /// </summary>
    public bool IsNotificationsEnabled { get; private set; }

    /// <summary>
    /// Включено ли распознавание движение
    /// </summary>
    public bool IsMotionRecognitionEnabled { get; private set; }
}