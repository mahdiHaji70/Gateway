using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{

    public class SendIpasTerminalDischargeCommandHandler : IRequestHandler<SendIpasTerminalDischargeCommand, bool>
    {
        private readonly ITerminalDischargeRepository _terminalDischargeRepository;
        private readonly ITerminalDischargeExternalService _terminalDischargeExternalService;
        private readonly IUnitOfWork _unitOfWork;

        public SendIpasTerminalDischargeCommandHandler(IUnitOfWork unitOfWork
            , ITerminalDischargeRepository terminalDischargeRepository
            , ITerminalDischargeExternalService terminalDischargeExternalService)
        {
            _unitOfWork = unitOfWork;
            _terminalDischargeRepository = terminalDischargeRepository;
            _terminalDischargeExternalService = terminalDischargeExternalService;

        }

        public async Task<bool> Handle(SendIpasTerminalDischargeCommand request, CancellationToken cancellationToken)
        {
            var terminalDischarges = await _terminalDischargeRepository.GetPendingIpasSubmissionByDeclarationIdAsync(request.DeclarationId);

            if (terminalDischarges == null || !terminalDischarges.Any())
                throw new NotFoundException("terminal discharge records not found for IPAS submission");

            foreach (var item in terminalDischarges)
            {
                var ipasDeclarationIdRequest = SendIpasTerminalDischargeRequestMapper.Map(item);
                var response = await _terminalDischargeExternalService.SendIpasTerminalDischarge(ipasDeclarationIdRequest);

            }



            return true;

        }
    }
}
