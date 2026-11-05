using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypeAndSizeLookup
{
    public class GetContainerTypeAndSizeLookupQueryHandler : IRequestHandler<GetContainerTypeAndSizeLookupQuery, PagedResult<ContainerTypeAndSizeDto>>
    {
        private readonly IContainerTypeAndSizeRepository _repository;
        private readonly IMapper _mapper;

        public GetContainerTypeAndSizeLookupQueryHandler(IContainerTypeAndSizeRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<ContainerTypeAndSizeDto>> Handle(GetContainerTypeAndSizeLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<ContainerTypeAndSizeDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
