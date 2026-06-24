using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{
    public class SendIpasTerminalDischargeResponse
    {
        public Guid TerminalDischargeId { get; set; }
        public Guid IpasTerminalDischargeId { get; set; }
        public string ErrorMessage { get; set; }
       
    }
}
