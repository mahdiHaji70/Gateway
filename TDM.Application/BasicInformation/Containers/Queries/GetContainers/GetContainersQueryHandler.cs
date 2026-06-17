using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.BasicInformation.Containers.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Containers.Queries.GetContainers
{
    public class GetContainersQueryHandler : IRequestHandler<GetContainersQuery, PagedResult<ContainerDto>>
    {
        private readonly IContainerRepository _containerRepository;
        private readonly IMapper _mapper;

        public GetContainersQueryHandler(IMapper mapper,
            IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ContainerDto>> Handle(
        GetContainersQuery request,
        CancellationToken cancellationToken)
        {
            var containers = await _containerRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<ContainerDto>>(containers);
        }
    }
}
