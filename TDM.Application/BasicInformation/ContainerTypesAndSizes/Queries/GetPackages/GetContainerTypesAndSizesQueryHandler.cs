using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypesAndSizes
{
    public class GetContainerTypesAndSizesQueryHandler : IRequestHandler<GetContainerTypesAndSizesQuery, PagedResult<ContainerTypeAndSizeDto>>
    {
        private readonly IContainerTypeAndSizeRepository _containerTypeAndSizeRepository;
        private readonly IMapper _mapper;

        public GetContainerTypesAndSizesQueryHandler(IMapper mapper,
            IContainerTypeAndSizeRepository containerTypeAndSizeRepository)
        {
            _containerTypeAndSizeRepository = containerTypeAndSizeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ContainerTypeAndSizeDto>> Handle(
        GetContainerTypesAndSizesQuery request,
        CancellationToken cancellationToken)
        {
            var containerTypesAndSizes = await _containerTypeAndSizeRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<ContainerTypeAndSizeDto>>(containerTypesAndSizes);
        }
    }
}
