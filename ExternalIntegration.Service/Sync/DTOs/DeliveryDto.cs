namespace ExternalIntegration.Service.Sync.DTOs
{
    public class DeliveryDto
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
        public List<GeneralCargoDeliveryDto> GeneralCargoList { get; set; } = [];
        public List<BulkDeliveryDto> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
