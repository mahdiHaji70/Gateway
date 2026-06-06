using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class TruckTerminalDischargeRequestDto
    {
        public string TerminalCode { get; set; }
        public string AgreementNo { get; set; }
        public string WaybillNo { get; set; }
        public Guid WaybillId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string TruckPlateNumber { get; set; }
        public float TruckEmptyWeight { get; set; }
        public float TruckFullWeight { get; set; }
        public string Tallyman { get; set; }
        public DateTime GateInDateTime { get; set; }
        public DateTime GateOutDateTime { get; set; }
        public List<GeneralCargoTruckTerminalDischargeRequestDto> GeneralCargoList { get; set; }
        public List<BulkTruckTerminalDischargeRequestDto> BulkList { get; set; }
        public List<ContainerTruckTerminalDischargeRequestDto> ContainerList { get; set; }
    }
}
