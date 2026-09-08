namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class LoadingPermitConfirmationRequestDto
    {
        public string TerminalCode { get; set; }
        public Guid PermitId { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }
    }
}
