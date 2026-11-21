namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class DeliveryRequestDto
    {
        public Guid LoadingPermitId { get; set; }
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNo { get; set; } = null!;
        public DateTime LoadingStart { get; set; }
        public DateTime LoadingFinish { get; set; }
        public string? Remark { get; set; }
        public string StorageAreaCode { get; set; } = null!;
        public DateTime FirstPortDischargeDate { get; set; }
        public DateTime FirstTerminalDischargeDate { get; set; }
        public List<GeneralCargoDeliveryRequestDto> GeneralCargoList { get; set; } = [];
        public List<BulkDeliveryRequestDto> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
