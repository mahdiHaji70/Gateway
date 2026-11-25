namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class ContainerAllocationsQueryRequestDto
    {
        public string TerminalCode { get; set; } = string.Empty;
        public string VoyageNoticeNo { get; set; } = string.Empty;
    }
}
