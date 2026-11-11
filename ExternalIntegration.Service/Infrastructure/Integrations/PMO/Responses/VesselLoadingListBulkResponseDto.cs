namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class VesselLoadingListBulkResponseDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float? Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool? DangerousNotNoticed { get; set; }
        public string PortOfDischarge { get; set; }
        public string PortOfDestination { get; set; }
        public string MovementType { get; set; }
        public string Remark { get; set; }
    }
}
