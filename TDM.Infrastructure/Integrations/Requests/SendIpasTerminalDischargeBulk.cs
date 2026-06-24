using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendIpasTerminalDischargeBulk
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float? Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public SendIpasTerminalDischargeDangerousSpecification DangerousSpecification { get; set; }
        public string Remark { get; set; }
    }
}
