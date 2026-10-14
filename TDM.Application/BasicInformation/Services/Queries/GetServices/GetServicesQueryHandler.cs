using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Services.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Services.Queries.GetServices
{
    public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, PagedResult<ServiceDto>>
    {
        private readonly IRepository<Service> _serviceRepository;
        private readonly IMapper _mapper;

        public GetServicesQueryHandler(IMapper mapper, IRepository<Service> serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<PagedResult<ServiceDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceRepository.GetPagedAsync(request.PageNumber, request.PageSize);
            return _mapper.Map<PagedResult<ServiceDto>>(services);
        }
    }
}
