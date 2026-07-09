namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class VoyageVesselDataResponseDto
    {
        public string Name { get; set; }
        public string Imo { get; set; }
        public string CallSign { get; set; }
        public float? Dwt { get; set; }
        public string Nrt { get; set; }
        public string TotalTEU { get; set; }
        public string Draft { get; set; }
        public float Grt { get; set; }
        public float Loa { get; set; }
        public string RegistrationNo { get; set; }
        public string PortOfRegistration { get; set; }
    }
}