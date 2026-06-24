using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{
    public class SendIpasTerminalDischargeDangerousSpecificationRequest
    {
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal? IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
    }
}
