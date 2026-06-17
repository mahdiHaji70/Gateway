using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.Commands.CreateTerminalDischarge
{

    public class CreateTerminalDischargeCommandHandler : IRequestHandler<CreateTerminalDischargeCommand, Guid>
    {
        private readonly IRepository<TerminalDischarge> _TerminalDischargeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTerminalDischargeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<TerminalDischarge> TerminalDischargeRepository)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork = unitOfWork;
            _TerminalDischargeRepository = TerminalDischargeRepository;
        }

        public async Task<Guid> Handle(CreateTerminalDischargeCommand request, CancellationToken cancellationToken)
        {
            var terminalDischarge = new TerminalDischarge(
                                          request.TerminalCode,
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

            await _TerminalDischargeRepository.InsertAsync(terminalDischarge);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return terminalDischarge.Id;
        }

    }
}
