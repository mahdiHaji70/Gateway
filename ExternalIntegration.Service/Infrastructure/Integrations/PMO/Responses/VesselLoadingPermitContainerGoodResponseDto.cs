namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class VesselLoadingPermitContainerGoodResponseDto
    {
        public string HSCode { get; set; }
        public string PackageTypeCode { get; set; }
        public string Description { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal Weight { get; set; }
    }
}
