using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Traffics.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Traffics.Queries.GetTrafficById
{
    public class GetTrafficByIdQueryHandler : IRequestHandler<GetTrafficByIdQuery, TrafficDto>
    {
        private readonly IRepository<Traffic> _trafficRepository;
        private readonly IMapper _mapper;

        public GetTrafficByIdQueryHandler(IMapper mapper,
            IRepository<Traffic> trafficRepository)
        {
            _trafficRepository = trafficRepository;
            _mapper = mapper;
        }

        public async Task<TrafficDto> Handle(GetTrafficByIdQuery request, CancellationToken cancellationToken)
        {
            var traffic = await _trafficRepository.GetAsync(request.Id);

            if (traffic == null)
                throw new NotFoundException("Traffic");

            return _mapper.Map<TrafficDto>(traffic);

        }
    }
}
