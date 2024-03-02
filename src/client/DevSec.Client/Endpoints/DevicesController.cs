using AForge.Video.DirectShow;
using DevSec.Client.Commands;
using DevSec.Client.Core.Entities;
using MediatR;
using DevSec.Client.Services;
using Kernel.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using DevSec.Client.Core.Repositories;

namespace DevSec.Client.Controllers;

[Route("[controller]")]
public class DevicesController : ControllerBase
{
    [HttpGet]
    public Task<PagedList<Device>> GetDevices(
        int page,
        int pageSize,
        [FromServices] IDeviceRepository deviceRepository,
        CancellationToken cancellationToken = default) =>
        deviceRepository.GetAsync(page, pageSize, cancellationToken);

    [HttpPost]
    public Task<Device> CreateDevice(
        CreateDevice.Request request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken = default) =>
        sender.Send(request, cancellationToken);

    [HttpGet("CaptureDevices")]
    public Task<IReadOnlyCollection<FilterInfo>> GetCaptureDevices(
        [FromServices] IDevicesService devicesService) =>
        Task.FromResult(devicesService.GetVideoDevices());
}
