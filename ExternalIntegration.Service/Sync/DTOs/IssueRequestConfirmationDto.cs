namespace ExternalIntegration.Service.Sync.DTOs
{
    public class IssueRequestConfirmationDto
    {
        public string TerminalCode { get; set; }
        public Guid RequestId { get; set; }
        public bool IsApproved { get; set; }
        public string Description { get; set; }
    }
}
