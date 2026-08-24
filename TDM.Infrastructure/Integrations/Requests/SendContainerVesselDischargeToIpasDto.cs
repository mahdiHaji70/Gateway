using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendContainerVesselDischargeToIpasDto
    {
        public string ContainerNo { get; set; } = null!;
        public string ContainerTypeAndSizeCode { get; set; } = null!;
        public string SealNumber { get; set; } = null!;
        public string? Remark { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }

        public SendDangerousSpecificationVesselDischargeToIpasDto DangerousSpecification { get; set; } = new();
        public SendVesselDischargeSpecificationToIpasDto DischargeSpecification { get; set; } = new();
    }
}
