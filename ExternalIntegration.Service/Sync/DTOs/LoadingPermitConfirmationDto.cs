namespace ExternalIntegration.Service.Sync.DTOs
{
    public class LoadingPermitConfirmationDto
    {
        public string TerminalCode { get; set; }
        public Guid PermitId { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }
    }
}
