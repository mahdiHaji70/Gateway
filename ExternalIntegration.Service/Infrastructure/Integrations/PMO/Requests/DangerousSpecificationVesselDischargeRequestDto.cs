namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class DangerousSpecificationVesselDischargeRequestDto
    {
        public string? DangerousCode { get; set; }
        public string? Classification { get; set; }
        public decimal IgnitionTemperature { get; set; }
        public string? IgnitionTemperatureUnit { get; set; }
    }
}
