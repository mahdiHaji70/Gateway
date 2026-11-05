using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Services.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Services.Queries.GetServiceLookup
{
    public class GetServiceLookupQueryHandler : IRequestHandler<GetServiceLookupQuery, PagedResult<ServiceDto>>
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public GetServiceLookupQueryHandler(IServiceRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<ServiceDto>> Handle(GetServiceLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<ServiceDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
