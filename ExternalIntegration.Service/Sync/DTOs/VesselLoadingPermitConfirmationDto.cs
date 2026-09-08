namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselLoadingPermitConfirmationDto
    {
        public string TerminalCode { get; set; }
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public string Remark { get; set; }
    }
}
