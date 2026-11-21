namespace ExternalIntegration.Service.Sync.DTOs
{
    public class TallySubmissionDto
    {
        public Guid LoadingPermitId { get; set; }
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNo { get; set; } = null!;
        public DateTime LoadingStart { get; set; }
        public DateTime LoadingFinish { get; set; }
        public string? Remark { get; set; }
        public List<GeneralCargoTallySubmissionDto> GeneralCargoList { get; set; } = [];
        public List<BulkTallySubmissionDto> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
