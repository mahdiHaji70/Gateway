using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendVesselDischargeToIpasDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string VoyageNoticeNo { get; set; } = null!;
        public string TerminalCode { get; set; } = null!;
        public string BillOfLadingId { get; set; } = null!;
        public string TallyMan { get; set; } = null!;
        public string CarrierIdNumber { get; set; } = null!;
        public int CarrierType { get; set; }
        public decimal CarrierEmptyWeight { get; set; }
        public decimal CarrierFullWeight { get; set; }
        public DateTime GateInDateTime { get; set; }
        public DateTime GateOutDateTime { get; set; }
        public bool IsFullyDischargedNoticed { get; set; }
        public string? Remark { get; set; }

        public List<SendGeneralCargoVesselDischargeToIpasDto> GeneralCargoList { get; set; } = [];
        public List<SendBulkVesselDischargeToIpasDto> BulkList { get; set; } = [];
        public List<SendContainerVesselDischargeToIpasDto> ContainerList { get; set; } = [];
    }
}
