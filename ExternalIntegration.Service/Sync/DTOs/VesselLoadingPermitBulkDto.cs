namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselLoadingPermitBulkDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
        public string Remark { get; set; }
        public VesselLoadingPermitDangerousSpecificationDto DangerousSpecification { get; set; }
    }
}
