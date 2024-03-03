using MediatR;
using DevSec.Client.Shared;
using Microsoft.AspNetCore.Mvc;
using Kernel.Shared.Extensions;
using MicroEndpoints.Attributes;
using MicroEndpoints.FluentGenerics;
using DevSec.Client.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace DevSec.Client.Endpoints.Devices;

public sealed class GetDevicesEndpoint : EndpointBaseAsync
    .WithQuery<int, int>
    .WithResult<PagedList<DeviceDTO>>
{
    [Get("api/devices")]
    public override Task<PagedList<DeviceDTO>> Handle([FromServices] IServiceProvider serviceProvider,
        int page,
        int pageSize, CancellationToken cancellationToken = default)
    {
        return serviceProvider
            .GetRequiredService<ISender>()
            .Send(new GetDevices.Query(page, pageSize));
    }
}