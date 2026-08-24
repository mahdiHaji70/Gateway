using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendDangerousSpecificationVesselDischargeToIpasDto
    {
        public string? DangerousCode { get; set; }
        public string? Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string? IgnitionTemperatureUnit { get; set; }
    }
}
