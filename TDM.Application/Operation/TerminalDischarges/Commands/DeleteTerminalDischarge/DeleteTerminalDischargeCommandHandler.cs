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
        private readonly IRepository<TerminalDischarge> _terminalDischargeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTerminalDischargeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<TerminalDischarge> terminalDischargeRepository)
        {
            _unitOfWork = unitOfWork;
            _terminalDischargeRepository = terminalDischargeRepository;
        }

        public async Task<bool> Handle(DeleteTerminalDischargeCommand request, CancellationToken cancellationToken)
        {
            var terminalDischarge = await _terminalDischargeRepository.GetAsync(request.Id);

            if (terminalDischarge == null)
                throw new Exception("TerminalDischarge not found");

            _terminalDischargeRepository.Delete(terminalDischarge);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
