namespace ExternalIntegration.Service.Sync.DTOs
{
    public class LoadingPermitBulkDto
    {
        public string HSCode { get; set; } 
        public string Description { get; set; } 
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public Guid BillOfLadingId { get; set; }
        public string Remark { get; set; } 
        public LoadingPermitDangerousSpecificationDto DangerousSpecification { get; set; }
    }
}
