using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;
using TDM.Domain.Exceptions;

namespace TDM.Application.Operation.VesselDischarges.Commands.CreateVesselDischarge
{
    public class CreateVesselDischargeCommandHandler : IRequestHandler<CreateVesselDischargeCommand, Guid>
    {
        private readonly IVesselDischargeRepository _vesselDischargeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateVesselDischargeCommandHandler(IVesselDischargeRepository vesselDischargeRepository, IUnitOfWork unitOfWork)
        {
            _vesselDischargeRepository = vesselDischargeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateVesselDischargeCommand request, CancellationToken cancellationToken)
        {
            if (request.ManifestContainerId.HasValue &&
                request.ManifestContainerId.Value != Guid.Empty &&
                await _vesselDischargeRepository.ExistsByManifestContainerIdAsync(
                    request.ManifestContainerId.Value,
                    cancellationToken))
            {
                throw new DomainValidationException("The manifest container has already been discharged.");
            }

            var vesselDischarge = new VesselDischarge(
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

            await _vesselDischargeRepository.InsertAsync(vesselDischarge);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return vesselDischarge.Id;
        }
    }
}
