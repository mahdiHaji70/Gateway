namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class IssueRequestConfirmationRequestDto
    {
        public string TerminalCode { get; set; }
        public Guid RequestId { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }
    }
}
