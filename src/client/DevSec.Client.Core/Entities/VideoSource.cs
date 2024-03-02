namespace DevSec.Client.Core.Entities;

public sealed class VideoSource(string sourcePath) : EntityBase<Guid>
{ 
    /// <summary>
    /// Источник видео
    /// </summary>
    public string Path { get; private set; } = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
}
