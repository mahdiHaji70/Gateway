namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class VesselLoadingPermitBulkResponseDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
        public string Remark { get; set; }
        public VesselLoadingPermitDangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}
