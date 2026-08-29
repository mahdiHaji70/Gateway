namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class LoadingPermitBulkResponseDto
    {
        public string HSCode { get; set; } 
        public string Description { get; set; } 
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public Guid BillOfLadingId { get; set; }
        public string Remark { get; set; } 
        public LoadingPermitDangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}
