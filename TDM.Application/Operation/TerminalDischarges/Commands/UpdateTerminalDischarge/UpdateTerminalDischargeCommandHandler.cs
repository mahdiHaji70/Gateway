using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.Commands.UpdateTerminalDischarge
{
  
    public class UpdateTerminalDischargeCommandHandler : IRequestHandler<UpdateTerminalDischargeCommand, Guid>
    {

        private readonly IRepository<TerminalDischarge> _terminalDischargeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTerminalDischargeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<TerminalDischarge> terminalDischargeRepository)
        {
            _unitOfWork = unitOfWork;
            _terminalDischargeRepository = terminalDischargeRepository;
        }

        public async Task<Guid> Handle(UpdateTerminalDischargeCommand request, CancellationToken cancellationToken)
        {
            var terminalDischarge = await _terminalDischargeRepository.GetAsync(request.Id);

            if (terminalDischarge == null)
                throw new Exception("terminaldischarge not found");

            terminalDischarge.Update(  request.TerminalCode,
                                       request.CargoTypeId,
                                       request.StoreId,
                                       request.DeclarationItemId,
                                       request.WayBillNo,
                                       request.WayBillId,
                                       request.DischargeDate,
                                       request.VehicleNumber,
                                       request.PackNB,
                                       request.Weight,
                                       request.Volume,
                                       request.IsNonPalletized,
                                       request.IsDamaged,
                                       request.IsVoluminous,
                                       request.IsDangerous,
                                       request.DangerousCode,
                                       request.Classification,
                                       request.IgnitionTemperature,
                                       request.IgnitionTemperatureUnit
                                   );

            _terminalDischargeRepository.Update(terminalDischarge);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return terminalDischarge.Id;
        }
    }
}
