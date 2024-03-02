namespace DevSec.Client.Core.Entities;

public sealed class SoundSource : EntityBase<Guid>
{
    private SoundSource() { }

    public SoundSource(string moniker)
    {
        Moniker = moniker;
    }

    /// <summary>
    /// Источник звука
    /// </summary>
    public string Moniker { get; private set; } 
}
