using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas
{
    public class SendVesselDischargeToIpasResponse
    {
        public Guid VesselDischargeId { get; set; }
        public Guid IpasVesselDischargeId { get; set; }
        public string ErrorMessage { get; set; } = null!;
    }
}
