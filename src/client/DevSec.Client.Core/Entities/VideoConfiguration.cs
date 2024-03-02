namespace DevSec.Client.Core.Entities;

public sealed class VideoConfiguration(
    int height,
    int width,
    int framesPerSecond) : EntityBase<Guid>
{
    /// <summary>
    /// Высота изображения
    /// </summary>
    public int Height { get; private set; } = height;
    
    /// <summary>
    /// Ширина изображения
    /// </summary>
    public int Width { get; private set; } = width;

    /// <summary>
    /// Количество кадров в секунду
    /// </summary>
    public int FramesPerSecond { get; private set; } = framesPerSecond;
}
