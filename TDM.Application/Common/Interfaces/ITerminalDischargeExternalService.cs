using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;

namespace TDM.Application.Common.Interfaces
{
    public interface ITerminalDischargeExternalService
    {
        Task<SendIpasTerminalDischargeResponse> SendIpasTerminalDischarge(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest, CancellationToken cancellationToken = default);

    }
}
