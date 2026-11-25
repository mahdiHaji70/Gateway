namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class TallyQuantityVarianceConfirmationRequestDto
    {
        public string TerminalCode { get; set; } = string.Empty;
        public Guid Id { get; set; }
    }
}
