namespace DevSec.Client.Core.Entities;

public sealed class DeviceLocation {
    public DeviceLocation(float latitude, float longtitude) 
    {
        Latitude = latitude;
        Longtitude = longtitude;
    }

    /// <summary>
    /// Долгота
    /// </summary>
    public float Latitude { get; private set; }

    /// <summary>
    /// Широта
    /// </summary>
    public float Longtitude { get; private set; }
}