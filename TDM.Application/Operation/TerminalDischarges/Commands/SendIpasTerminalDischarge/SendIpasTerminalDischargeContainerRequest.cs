using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{
    public class SendIpasTerminalDischargeContainerRequest
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public SendIpasTerminalDischargeDangerousSpecificationRequest DangerousSpecification { get; set; }
    }
}
