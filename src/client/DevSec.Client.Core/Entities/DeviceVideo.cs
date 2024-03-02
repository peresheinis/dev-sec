namespace DevSec.Client.Core.Entities;

public sealed class DeviceVideo(VideoSource videoSource, VideoConfiguration videoConfiguration) : EntityBase
{
    public VideoSource Source { get; private set; } = videoSource;
    public VideoConfiguration Configuration { get; private set; } = videoConfiguration;
}
