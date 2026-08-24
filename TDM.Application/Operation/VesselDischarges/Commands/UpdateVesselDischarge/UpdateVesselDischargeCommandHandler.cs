using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.VesselDischarges.Commands.UpdateVesselDischarge
{
    public class UpdateVesselDischargeCommandHandler : IRequestHandler<UpdateVesselDischargeCommand, Guid>
    {
        private readonly IVesselDischargeRepository _vesselDischargeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateVesselDischargeCommandHandler(IVesselDischargeRepository vesselDischargeRepository
            , IUnitOfWork unitOfWork)
        {
            _vesselDischargeRepository = vesselDischargeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateVesselDischargeCommand request, CancellationToken cancellationToken)
        {
            var vesselDischarge = await _vesselDischargeRepository.GetAsync(request.Id);

            if (vesselDischarge == null)
                throw new Exception("terminaldischarge not found");

            vesselDischarge.Update(
               terminalCode: request.TerminalCode,
               storeId: request.StoreId,
               manifestItemId: request.ManifestItemId,
               manifestContainerId: request.ManifestContainerId,
               dischargeDate: request.DischargeDate,
               packNB: request.PackNB,
               weight: request.Weight,
               volume: request.Volume,
               isNonPalletized: request.IsNonPalletized,
               isDamaged: request.IsDamaged,
               isVoluminous: request.IsVoluminous,
               isDangerous: request.IsDangerous,
               dangerousCode: request.DangerousCode,
               classification: request.Classification,
               ignitionTemperature: request.IgnitionTemperature,
               ignitionTemperatureUnit: request.IgnitionTemperatureUnit,
               unitWeight: request.UnitWeight);

            _vesselDischargeRepository.Update(vesselDischarge);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return vesselDischarge.Id;
        }
    }
}
