
namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselDischargeDto
    {
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

        public List<GeneralCargoVesselDischargeDto> GeneralCargoList { get; set; } = [];
        public List<BulkVesselDischargeDto> BulkList { get; set; } = [];
        public List<ContainerVesselDischargeDto> ContainerList { get; set; } = [];

    }
}
