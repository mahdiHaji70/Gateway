namespace TDM.Infrastructure.Integrations.Responses
{
    public class IssueRequestContainerGoodResponseDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public decimal PackageQuantity { get; set; }
        public string PackageTypeCode { get; set; }
    }
}