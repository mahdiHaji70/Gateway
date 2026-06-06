namespace ExternalIntegration.Service.Sync.DTOs
{
    public class TruckTerminalDischargeDto
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
        public List<GeneralCargoTruckTerminalDischargeDto> GeneralCargoList { get; set; }
        public List<BulkTruckTerminalDischargeDto> BulkList { get; set; }
        public List<ContainerTruckTerminalDischargeDto> ContainerList { get; set; }
    }
}
