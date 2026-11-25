namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ContainerAllocationResponseDto
    {
        public string ContainerTypeAndSizeCode { get; set; } = string.Empty;
        public string ContainerType { get; set; } = string.Empty;
        public int DangerousAssigned { get; set; }
        public int EmptyAssigned { get; set; }
        public int LclAssigned { get; set; }
        public int FclAssigned { get; set; }
    }
}
