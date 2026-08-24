using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas
{
    public class SendVesselDischargeToIpasCommandHandler : IRequestHandler<SendVesselDischargeToIpasCommand, List<SendVesselDischargeToIpasResponse>>
    {
        private readonly IVesselDischargeRepository _vesselDischargeRepository;
        private readonly IVesselDischargeExternalService _vesselDischargeExternalService;
        private readonly IUnitOfWork _unitOfWork;

        public SendVesselDischargeToIpasCommandHandler(IUnitOfWork unitOfWork
            , IVesselDischargeRepository vesselDischargeRepository
            , IVesselDischargeExternalService vesselDischargeExternalService)
        {
            _vesselDischargeRepository = vesselDischargeRepository;
            _vesselDischargeExternalService = vesselDischargeExternalService;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SendVesselDischargeToIpasResponse>> Handle(SendVesselDischargeToIpasCommand request, CancellationToken cancellationToken)
        {
            var vesselDischarges = await _vesselDischargeRepository.GetUnsentVesselDischargesToIpasAsync(request.ManifestItemId);

            if (vesselDischarges == null || !vesselDischarges.Any())
                throw new NotFoundException("Vessel discharge records not found for IPAS submission");

            var sendVesselDischargeToIpasRequests = SendVesselDischargeToIpasRequestMapper.Map(vesselDischarges);
            var response = await _vesselDischargeExternalService.SendVesselDischargeToIpas(sendVesselDischargeToIpasRequests);

            vesselDischarges.Join(response,
            vd => vd.Id,
            r => r.VesselDischargeId,
            (vd, r) => new { VesselDischarge = vd, Response = r })
             .ToList()
             .ForEach(pair => pair.VesselDischarge.SetIpasReceived(pair.Response.IpasVesselDischargeId, DateTime.Now));

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
