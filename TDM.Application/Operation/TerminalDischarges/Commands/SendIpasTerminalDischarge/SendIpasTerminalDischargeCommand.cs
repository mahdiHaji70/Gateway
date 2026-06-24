using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{
    public record SendIpasTerminalDischargeCommand : IRequest<List<SendIpasTerminalDischargeResponse>>
    {
        public Guid DeclarationId { get; set; }

        public SendIpasTerminalDischargeCommand(Guid declarationId)
        {
            DeclarationId = declarationId;
        }
    }
}
