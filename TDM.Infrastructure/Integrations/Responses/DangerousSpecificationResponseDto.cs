namespace TDM.Infrastructure.Integrations.Responses
{
    public class DangerousSpecificationResponseDto
    {
        public string DangerousCode { get; set; }
        public string Classification { get; set; }
        public decimal? IgnitionTemperature { get; set; }
        public string IgnitionTemperatureUnit { get; set; }
    }
}