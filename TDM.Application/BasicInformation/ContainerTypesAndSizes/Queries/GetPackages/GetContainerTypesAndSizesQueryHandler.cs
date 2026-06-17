using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypesAndSizes
{
    public class GetContainerTypesAndSizesQueryHandler : IRequestHandler<GetContainerTypesAndSizesQuery, PagedResult<ContainerTypeAndSizeDto>>
    {
        private readonly IRepository<ContainerTypeAndSize> _containerTypeAndSizeRepository;
        private readonly IMapper _mapper;

        public GetContainerTypesAndSizesQueryHandler(IMapper mapper,
            IRepository<ContainerTypeAndSize> containerTypeAndSizeRepository)
        {
            _containerTypeAndSizeRepository = containerTypeAndSizeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ContainerTypeAndSizeDto>> Handle(
        GetContainerTypesAndSizesQuery request,
        CancellationToken cancellationToken)
        {
            var containerTypesAndSizes = await _containerTypeAndSizeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<ContainerTypeAndSizeDto>>(containerTypesAndSizes);
        }
    }
}
