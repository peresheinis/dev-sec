namespace DevSec.Client.Core.Entities;

public sealed class DeviceConfiguration(
    bool isCompressEnabled, 
    bool isNotificationsEnabled, 
    bool isMotionRecognitionEnabled) : EntityBase<Guid>
{
    /// <summary>
    /// Включено ли сжатие для кадров изображения
    /// </summary>
    public bool IsCompressEnabled { get; private set; } = isCompressEnabled;

    /// <summary>
    /// Включены ли оповещения о событиях на камере
    /// </summary>
    public bool IsNotificationsEnabled { get; private set; } = isNotificationsEnabled;

    /// <summary>
    /// Включено ли распознавание движение
    /// </summary>
    public bool IsMotionRecognitionEnabled { get; private set; } = isMotionRecognitionEnabled;
}