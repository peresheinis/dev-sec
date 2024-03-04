using DevSec.Client.Application.Queries;
using DevSec.Client.Shared;
using Kernel.Shared.Extensions;
using MediatR;
using MicroEndpoints.Attributes;
using MicroEndpoints.FluentGenerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DevSec.Client.Endpoints.Devices;

public static partial class Devices
{
    public class Get : EndpointBaseAsync
        .WithQuery<int, int>
        .WithResult<PagedList<DeviceDTO>>
    {
        [Get("api/devices")]
        public override Task<PagedList<DeviceDTO>> HandleAsync(
            [FromServices] IServiceProvider serviceProvider,
            int page,
            int pageSize, CancellationToken cancellationToken = default) =>
            serviceProvider
                .GetRequiredService<ISender>()
                .Send(new GetDevices.Query(page, pageSize), cancellationToken);
    }
}
