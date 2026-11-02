using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Containers.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Containers.Queries.GetContainerLookup
{
    public class GetContainerLookupQueryHandler : IRequestHandler<GetContainerLookupQuery, PagedResult<ContainerDto>>
    {
        private readonly IContainerRepository _repository;
        private readonly IMapper _mapper;

        public GetContainerLookupQueryHandler(IContainerRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<ContainerDto>> Handle(GetContainerLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<ContainerDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
