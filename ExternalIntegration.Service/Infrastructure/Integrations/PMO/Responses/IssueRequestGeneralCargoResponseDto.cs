using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class IssueRequestGeneralCargoResponseDto
    {
        public string HsCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal? Volume { get; set; }
        public bool? IsDangerous { get; set; }
        public string Remark { get; set; }
        public Guid? BillOfLadingId { get; set; }
        public bool? DangerousNotNoticed { get; set; }
        public DangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}