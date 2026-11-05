using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Traffics.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Traffics.Queries.GetTrafficLookup
{
    public class GetTrafficLookupQueryHandler : IRequestHandler<GetTrafficLookupQuery, PagedResult<TrafficDto>>
    {
        private readonly ITrafficRepository _repository;
        private readonly IMapper _mapper;

        public GetTrafficLookupQueryHandler(ITrafficRepository repository, IMapper mapper)
        { _repository = repository; _mapper = mapper; }

        public async Task<PagedResult<TrafficDto>> Handle(GetTrafficLookupQuery request, CancellationToken cancellationToken)
            => _mapper.Map<PagedResult<TrafficDto>>(await _repository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search));
    }
}
