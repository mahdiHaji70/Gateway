namespace ExternalIntegration.Service.Sync.DTOs
{
    public class IssueRequestGeneralCargoDto
    {
        public string HsCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal? Volume { get; set; }
        public bool? IsDangerous { get; set; }
        public string Remark { get; set; }
        public Guid? BillOfLadingId { get; set; }
        public bool? DangerousNotNoticed { get; set; }
        public DangerousSpecificationDto DangerousSpecification { get; set; }
    }
}
