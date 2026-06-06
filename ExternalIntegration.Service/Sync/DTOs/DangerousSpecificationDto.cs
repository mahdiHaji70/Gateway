namespace ExternalIntegration.Service.Sync.DTOs
{
    public class DangerousSpecificationDto
    {
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal? IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
    }
}
