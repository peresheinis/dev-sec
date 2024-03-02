namespace DevSec.Client.Core.Entities;

public sealed class VideoConfiguration(
    int height,
    int width,
    int framesPerSecond) : EntityBase<Guid>
{
    public int Height { get; private set; } = height;
    public int Width { get; private set; } = width;
    public int FramesPerSecond { get; private set; } = framesPerSecond;
}
