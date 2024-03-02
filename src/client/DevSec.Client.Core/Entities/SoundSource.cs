namespace DevSec.Client.Core.Entities;

public sealed class SoundSource(string sourcePath) : EntityBase<Guid>
{
    /// <summary>
    /// Источник звука
    /// </summary>
    public string Path { get; private set; } = sourcePath;
}
