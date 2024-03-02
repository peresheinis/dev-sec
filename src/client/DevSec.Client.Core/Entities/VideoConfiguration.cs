namespace DevSec.Client.Core.Entities;

public sealed class VideoConfiguration : EntityBase<Guid>
{
    private VideoConfiguration() { }

    public VideoConfiguration(int height, int width, int framesPerSeconds)
    {
        Width = width;
        Height = height;
        FramesPerSecond = framesPerSeconds;
    }

    /// <summary>
    /// Высота изображения
    /// </summary>
    public int Height { get; private set; }

    /// <summary>
    /// Ширина изображения
    /// </summary>
    public int Width { get; private set; }

    /// <summary>
    /// Количество кадров в секунду
    /// </summary>
    public int FramesPerSecond { get; private set; }
}
