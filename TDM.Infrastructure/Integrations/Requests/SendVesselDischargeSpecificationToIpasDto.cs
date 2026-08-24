using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendVesselDischargeSpecificationToIpasDto
    {
        public bool IsBundled { get; set; }
        public bool IsOG { get; set; }
        public bool IsUsedSpecialEquipment { get; set; }
        public string? SpecialEquipmentOwner { get; set; }
        public string CraneNo { get; set; } = null!;
        public string CraneDriver { get; set; } = null!;
        public string TallyMan { get; set; } = null!;
        public int HandlingTypeId { get; set; }
    }
}
