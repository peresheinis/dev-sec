namespace DevSec.Client.Core.Entities;

public sealed class SoundSource(string sourcePath) : EntityBase<Guid>
{
    public string Path { get; private set; } = sourcePath;
}
