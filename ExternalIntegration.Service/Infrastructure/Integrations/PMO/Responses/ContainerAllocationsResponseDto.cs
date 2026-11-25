namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ContainerAllocationsResponseDto
    {
        public string TerminalCode { get; set; } = string.Empty;
        public string Terminal { get; set; } = string.Empty;
        public List<ContainerAllocationResponseDto> Allocations { get; set; } = [];
    }
}
