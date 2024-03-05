using DevSec.Client.Application.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;

namespace DevSec.Client.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddMediator(this IServiceCollection serviceDescriptors) =>
        serviceDescriptors.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

    public static IServiceCollection AddRecordingManager(this IServiceCollection serviceDescriptors) =>
        serviceDescriptors.AddTransient<IDeviceRecordingManager, DeviceRecordingManager>();
}
