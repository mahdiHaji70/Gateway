using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Services.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Services.Queries.GetServiceById
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ServiceDto>
    {
        private readonly IRepository<Service> _serviceRepository;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IMapper mapper, IRepository<Service> serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetAsync(request.Id);

            if (service == null)
                throw new NotFoundException("Service");

            return _mapper.Map<ServiceDto>(service);
        }
    }
}
