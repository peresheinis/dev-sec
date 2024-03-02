namespace DevSec.Client.Core.Entities;

public sealed class DeviceLocation {
    public DeviceLocation(float latitude, float longtitude) 
    {
        Latitude = latitude;
        Longtitude = longtitude;
    }

    public float Latitude { get; private set; }
    public float Longtitude { get; private set; }
}