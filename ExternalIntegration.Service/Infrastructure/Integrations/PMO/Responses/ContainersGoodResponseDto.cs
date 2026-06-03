namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ContainersGoodResponseDto
    {
        public string? HSCode { get; set; }
        public string? Description { get; set; }
        public float weight { get; set; }
        public string? PackageTypeCode { get; set; }
        public float PackageQuantity { get; set; }
    }
}
