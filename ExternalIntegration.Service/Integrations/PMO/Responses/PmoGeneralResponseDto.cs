namespace ExternalIntegration.Service.Integrations.PMO.Responses
{
    public class PmoGeneralResponseDto
    {
        public int ResponseStatusCode { get; set; }

        public string? ResponseText { get; set; }

        public bool IsSuccessful { get; set; }

        public string? RequestDate { get; set; }
    }
}
