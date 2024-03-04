using AutoMapper;
using DevSec.Client.Application.Services;
using DevSec.Client.Shared;
using Kernel.Shared.Extensions;
using MediatR;

namespace DevSec.Client.Application.Queries;

public static class GetPhysicalDevices
{
    public record Query() : IRequest<IReadOnlyCollection<CaptureDeviceDTO>>;

    internal sealed class QueryHandler(
        IMapper mapper,
        IDevicesService devicesService) : IRequestHandler<Query, IReadOnlyCollection<CaptureDeviceDTO>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDevicesService _devicesService = devicesService;

        public Task<IReadOnlyCollection<CaptureDeviceDTO>> Handle(Query request, CancellationToken cancellationToken) =>
            Task.Run(_devicesService
                .GetVideoDevices)
                .ThenAsync(_mapper.Map<IReadOnlyCollection<CaptureDeviceDTO>>);

    }
}