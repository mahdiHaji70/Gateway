namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class VesselLoadingPermitConfirmationRequestDto
    {
        public string TerminalCode { get; set; }
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public string Remark { get; set; }
    }
}
