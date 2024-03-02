namespace DevSec.Client.Core.Entities;

public sealed class DeviceSound(SoundSource source) : EntityBase
{
    /// <summary>
    /// Источник звук
    /// </summary>
    public SoundSource Source { get; private set; } = source ?? throw new ArgumentNullException(nameof(source));
}
