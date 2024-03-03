namespace DevSec.Client.Core.Entities;

public sealed class DeviceSound : EntityBase<Guid>
{
    private DeviceSound() { }

    public DeviceSound(SoundSource source)
    {
        Source = source;
    }

    /// <summary>
    /// Источник звук
    /// </summary>
    public SoundSource Source { get; private set; }
}
