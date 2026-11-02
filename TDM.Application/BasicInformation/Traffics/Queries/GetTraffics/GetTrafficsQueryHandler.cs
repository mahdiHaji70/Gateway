using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Traffics.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Traffics.Queries.GetTraffics
{
    public class GetTrafficsQueryHandler : IRequestHandler<GetTrafficsQuery, PagedResult<TrafficDto>>
    {
        private readonly ITrafficRepository _trafficRepository;
        private readonly IMapper _mapper;

        public GetTrafficsQueryHandler(IMapper mapper,
            ITrafficRepository trafficRepository)
        {
            _trafficRepository = trafficRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TrafficDto>> Handle(
        GetTrafficsQuery request,
        CancellationToken cancellationToken)
        {
            var traffics = await _trafficRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<TrafficDto>>(traffics);
        }
    }
}
