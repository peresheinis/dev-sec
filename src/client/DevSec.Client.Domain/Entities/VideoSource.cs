namespace DevSec.Client.Core.Entities;

public sealed class VideoSource : EntityBase<Guid>
{
    private VideoSource() { }

    public VideoSource(string moniker)  {
        Moniker = moniker;
    }

    /// <summary>
    /// Источник видео
    /// </summary>
    public string Moniker { get; private set; } 
}
