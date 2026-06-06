using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class BulkTruckTerminalDischargeRequestDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float? Volume { get; set; }
        public bool ISDangerous { get; set; }
        public bool? DangerousNotNoticed { get; set; }
        public DangerousSpecificationRequestDto DangerousSpecification { get; set; }
        public string Remark { get; set; }
    }
}
