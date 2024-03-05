using AutoMapper;
using DevSec.Client.Core.Repositories;
using DevSec.Client.Shared;
using Kernel.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevSec.Client.Application.Queries;

public static class GetDevices
{
    public record Query(
        [FromQuery] int Page,
        [FromQuery] int PageSize) : IRequest<PagedList<DeviceDTO>>;

    internal sealed class QueryHandler(
        IMapper mapper,
        IDeviceRepository deviceRepository) : IRequestHandler<Query, PagedList<DeviceDTO>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDeviceRepository _deviceRepository = deviceRepository;

        public Task<PagedList<DeviceDTO>> Handle(Query request, CancellationToken cancellationToken) =>
            _deviceRepository
                .GetAsync(request.Page, request.PageSize, cancellationToken)
                .ThenAsync(_mapper.Map<PagedList<DeviceDTO>>);
    }
}