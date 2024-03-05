using Ardalis.ApiEndpoints;
using DevSec.Client.Application.Queries;
using DevSec.Client.Shared;
using Kernel.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DevSec.Client.Endpoints.Devices;

public class GetDevicesEndpoint : EndpointBaseAsync
    .WithRequest<GetDevices.Query>
    .WithResult<PagedList<DeviceDTO>>
{

    [HttpGet("api/devices")]
    [SwaggerOperation(
       Summary = "Get a pagedList devices",
       Description = "Get devices with pagination",
       OperationId = "Device_Get",
       Tags = new[] { "DevicesEndpoint" })]
    public override Task<PagedList<DeviceDTO>> HandleAsync(
        [FromQuery] GetDevices.Query request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}