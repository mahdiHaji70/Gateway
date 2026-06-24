using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{

    public class SendIpasTerminalDischargeCommandHandler : IRequestHandler<SendIpasTerminalDischargeCommand, List<SendIpasTerminalDischargeResponse>>
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

        public async Task<List<SendIpasTerminalDischargeResponse>> Handle(SendIpasTerminalDischargeCommand request, CancellationToken cancellationToken)
        {
            var terminalDischarges = await _terminalDischargeRepository.GetPendingIpasSubmissionByDeclarationIdAsync(request.DeclarationId);

            if (terminalDischarges == null || !terminalDischarges.Any())
                throw new NotFoundException("terminal discharge records not found for IPAS submission");

            var ipasTerminalDischargeRequest = SendIpasTerminalDischargeRequestMapper.Map(terminalDischarges);
            var response = await _terminalDischargeExternalService.SendIpasTerminalDischarge(ipasTerminalDischargeRequest);

           terminalDischarges.Join(response,
           td => td.Id,
           r => r.TerminalDischargeId,
           (td, r) => new { TerminalDischarge = td, Response = r })
            .ToList()
            .ForEach(pair => pair.TerminalDischarge.IpasTerminalDischargeId = pair.Response.IpasTerminalDischargeId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
