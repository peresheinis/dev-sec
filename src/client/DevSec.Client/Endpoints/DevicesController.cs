using AForge.Video.DirectShow;
using AutoMapper;
using DevSec.Client.Commands;
using DevSec.Client.Core.Entities;
using DevSec.Client.Core.Repositories;
using DevSec.Client.Extensions;
using DevSec.Client.Services;
using DevSec.Client.Shared;
using Kernel.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevSec.Client.Controllers;

[Route("[controller]")]
public class DevicesController : ControllerBase
{
    [HttpGet]
    public Task<PagedList<DeviceDTO>> GetDevices(
        int page,
        int pageSize,
        [FromServices] IMapper mapper,
        [FromServices] IDeviceRepository deviceRepository,
        CancellationToken cancellationToken = default) =>
        deviceRepository
            .GetAsync(page, pageSize, cancellationToken)
            .ThenAsync(mapper.Map<PagedList<DeviceDTO>>);

    [HttpPost]
    public Task<DeviceDTO> CreateDevice(
        CreateDevice.Request request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken = default) =>
        sender.Send(request, cancellationToken);

    [HttpGet("CaptureDevices")]
    public Task<IReadOnlyCollection<FilterInfo>> GetCaptureDevices(
        [FromServices] IDevicesService devicesService) =>
        Task.FromResult(devicesService.GetVideoDevices());
}