using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendContainerTerminalDischargeToIpasDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public SendDangerousSpecificationTerminalDischargeToIpasDto DangerousSpecification { get; set; }
    }
}
