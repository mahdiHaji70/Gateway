using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendBulkVesselDischargeToIpasDto
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float Weight { get; set; }
        public float Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public string? Remark { get; set; }
        public SendDangerousSpecificationVesselDischargeToIpasDto DangerousSpecification { get; set; } = new();
    }
}
