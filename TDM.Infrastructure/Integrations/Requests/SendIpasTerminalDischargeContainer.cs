using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendIpasTerminalDischargeContainer
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public SendIpasTerminalDischargeDangerousSpecification DangerousSpecification { get; set; }
    }
}
