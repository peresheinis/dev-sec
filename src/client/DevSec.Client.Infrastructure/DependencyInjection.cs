using DevSec.Client.Core.Repositories;
using DevSec.Client.Core;
using DevSec.Client.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DevSec.Client.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceDescriptors)
    {
        serviceDescriptors.AddDbContext<DatabaseContext>(configuration => configuration.UseSqlite("Filename=database.db"));
        serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceDescriptors.AddScoped<IDeviceRepository, DeviceRepository>();

        return serviceDescriptors;
    }
}
