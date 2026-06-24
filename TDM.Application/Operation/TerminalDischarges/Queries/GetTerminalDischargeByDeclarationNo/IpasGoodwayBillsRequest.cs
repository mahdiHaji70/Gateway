using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo
{
    public class IpasGoodwayBillsRequest
    {
        public string TerminalCode { get; set; }
        public Guid IpasDeclarationId { get; set; } = default!;

        public IpasGoodwayBillsRequest(string terminalCode, Guid ipasDeclarationId)
        {
            TerminalCode = terminalCode;
            IpasDeclarationId = ipasDeclarationId;
        }
    }
}
