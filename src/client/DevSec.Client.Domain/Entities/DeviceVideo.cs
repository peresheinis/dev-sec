namespace DevSec.Client.Core.Entities;

public sealed class DeviceVideo : EntityBase<Guid>
{
    private DeviceVideo() { }

    public DeviceVideo(VideoSource videoSource, VideoConfiguration videoConfiguration)
    {
        Source = videoSource;
        Configuration = videoConfiguration;
    }

    /// <summary>
    /// Источник видео
    /// </summary>
    public VideoSource Source { get; private set; }

    /// <summary>
    /// Конфигурация изображения
    /// </summary>
    public VideoConfiguration Configuration { get; private set; }
}
