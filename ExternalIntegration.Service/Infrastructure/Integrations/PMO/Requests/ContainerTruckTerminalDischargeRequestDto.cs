using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class ContainerTruckTerminalDischargeRequestDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public DangerousSpecificationRequestDto DangerousSpecification { get; set; }
    }
}
