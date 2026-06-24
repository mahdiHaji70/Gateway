using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo;

namespace TDM.Application.Common.Interfaces
{
    public interface ITerminalDischargeExternalService
    {
        Task<List<SendIpasTerminalDischargeResponse>> SendIpasTerminalDischarge(List<SendIpasTerminalDischargeRequest> sendIpasTerminalDischargeRequest, CancellationToken cancellationToken = default);
        Task<List<IpasGoodwayBillsResponse>> GetIpasGoodwayBills(IpasGoodwayBillsRequest ipasDeclarationItemsRequest, CancellationToken cancellationToken = default);
    }
}
