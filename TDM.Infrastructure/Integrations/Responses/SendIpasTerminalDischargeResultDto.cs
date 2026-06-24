using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class SendIpasTerminalDischargeResultDto
    {
        public Guid IpasTerminalDischargeId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
