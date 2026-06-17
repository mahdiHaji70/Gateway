using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.BasicInformation.Containers.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Containers.Queries.GetContainerById
{
    public class GetContainerByIdQueryHandler : IRequestHandler<GetContainerByIdQuery, ContainerDto>
    {
        private readonly IContainerRepository _containerRepository;
        private readonly IMapper _mapper;

        public GetContainerByIdQueryHandler(IMapper mapper,
            IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
            _mapper = mapper;
        }

        public async Task<ContainerDto> Handle(GetContainerByIdQuery request, CancellationToken cancellationToken)
        {
            var container = await _containerRepository.GetAsync(request.Id);

            if (container == null)
                throw new NotFoundException("Container");

            return _mapper.Map<ContainerDto>(container);

        }
    }
}
