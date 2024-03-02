namespace DevSec.Client.Core.Entities;

public sealed class DeviceVideo(VideoSource videoSource, VideoConfiguration videoConfiguration) : EntityBase
{
    /// <summary>
    /// Источник видео
    /// </summary>
    public VideoSource Source { get; private set; } = videoSource ?? throw new ArgumentNullException(nameof(videoSource));

    /// <summary>
    /// Конфигурация изображения
    /// </summary>
    public VideoConfiguration Configuration { get; private set; } = videoConfiguration ?? throw new ArgumentNullException(nameof(videoConfiguration));
}
