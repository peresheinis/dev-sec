namespace DevSec.Client.Shared;

public record DeviceConfigurationDTO(
    bool IsCompressionEnabled,
    bool IsNotificationsEnabled,
    bool IsMotionRecognitionEnabled);
