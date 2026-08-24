using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.VesselDischarges.DTOs;

namespace TDM.Application.Operation.VesselDischarges.Queries.GetGetVesselDischarges
{
   
    public class GetVesselDischargesQueryHandler : IRequestHandler<GetVesselDischargesQuery, PagedResult<VesselDischargeDto>>
    {
        private readonly IVesselDischargeRepository _vesselDischargeRepository;
        private readonly IMapper _mapper;

        public GetVesselDischargesQueryHandler(IMapper mapper,
            IVesselDischargeRepository vesselDischargeRepository)
        {
            _vesselDischargeRepository = vesselDischargeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<VesselDischargeDto>> Handle(
        GetVesselDischargesQuery request,
        CancellationToken cancellationToken)
        {
            var vesselDischarges = await _vesselDischargeRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<VesselDischargeDto>>(vesselDischarges);
        }
    }
}
