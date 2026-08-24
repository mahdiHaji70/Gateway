using AutoMapper;
using MediatR;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.VesselDischarges.DTOs;

namespace TDM.Application.Operation.VesselDischarges.Queries.GetVesselDischargeById
{
    public class GetVesselDischargeByIdQueryHandler : IRequestHandler<GetVesselDischargeByIdQuery, VesselDischargeDto>
    {
        private readonly IVesselDischargeRepository _vesselDischargeRepository;
        private readonly IMapper _mapper;

        public GetVesselDischargeByIdQueryHandler(IMapper mapper,
            IVesselDischargeRepository vesselDischargeRepository)
        {
            _vesselDischargeRepository = vesselDischargeRepository;
            _mapper = mapper;
        }

        public async Task<VesselDischargeDto> Handle(GetVesselDischargeByIdQuery request, CancellationToken cancellationToken)
        {
            var vesselDischarge = await _vesselDischargeRepository.GetAsync(request.Id);

            if (vesselDischarge == null)
                throw new NotFoundException("Vessel discharge");

            return _mapper.Map<VesselDischargeDto>(vesselDischarge);

        }

    }
}
