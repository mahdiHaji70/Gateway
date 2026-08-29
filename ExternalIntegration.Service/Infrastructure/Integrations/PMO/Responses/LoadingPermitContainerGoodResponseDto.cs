namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class LoadingPermitContainerGoodResponseDto
    {
        public string Hscode { get; set; } 
        public string Description { get; set; } 
        public string PackageTypeCode { get; set; } 
        public decimal PackageQuantity { get; set; }
        public decimal Weight { get; set; }
    }
}
