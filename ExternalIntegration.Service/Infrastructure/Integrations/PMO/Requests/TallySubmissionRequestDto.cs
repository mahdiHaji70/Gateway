namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class TallySubmissionRequestDto
    {
        public Guid LoadingPermitId { get; set; }
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNo { get; set; } = null!;
        public DateTime LoadingStart { get; set; }
        public DateTime LoadingFinish { get; set; }
        public string? Remark { get; set; }
        public List<GeneralCargoTallySubmissionRequestDto> GeneralCargoList { get; set; } = [];
        public List<BulkTallySubmissionRequestDto> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
