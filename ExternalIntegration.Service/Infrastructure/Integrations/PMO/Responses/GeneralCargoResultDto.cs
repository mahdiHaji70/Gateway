namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class GeneralCargoResultDto
    {
        public string? HSCode { get; set; }
        public string? Description { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public string? PackageType { get; set; }
        public string? PackageTypeCode { get; set; }
        public float? PackageQuantity { get; set; }
    }
}
