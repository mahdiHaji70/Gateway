using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.Commands.DeleteTerminalDischarge
{
   
    public class DeleteTerminalDischargeCommandHandler : IRequestHandler<DeleteTerminalDischargeCommand, bool>
    {
        private readonly IRepository<TerminalDischarge> _TerminalDischargeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTerminalDischargeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<TerminalDischarge> TerminalDischargeRepository)
        {
            _unitOfWork = unitOfWork;
            _TerminalDischargeRepository = TerminalDischargeRepository;
        }

        public async Task<bool> Handle(DeleteTerminalDischargeCommand request, CancellationToken cancellationToken)
        {
            var TerminalDischarge = await _TerminalDischargeRepository.GetAsync(request.Id);

            if (TerminalDischarge == null)
                throw new Exception("TerminalDischarge not found");

            _TerminalDischargeRepository.Delete(TerminalDischarge);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
