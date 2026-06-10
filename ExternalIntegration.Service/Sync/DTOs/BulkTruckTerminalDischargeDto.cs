namespace ExternalIntegration.Service.Sync.DTOs
{
    public class BulkTruckTerminalDischargeDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float? Volume { get; set; }
        public bool ISDangerous { get; set; }
        public bool? DangerousNotNoticed { get; set; }
        public DangerousSpecificationDto DangerousSpecification { get; set; }
        public string Remark { get; set; }
    }
}
