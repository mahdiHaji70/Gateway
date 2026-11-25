namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ContainerAllocationsDto
    {
        public string TerminalCode { get; set; } = string.Empty;
        public string Terminal { get; set; } = string.Empty;
        public List<ContainerAllocationDto> Allocations { get; set; } = [];
    }
}
