namespace DevSec.Client.Core.Entities;

public sealed class DeviceSound(SoundSource source) : EntityBase
{
    public SoundSource Source { get; private set; } = source;
}
