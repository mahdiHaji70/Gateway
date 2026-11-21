namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselLoadingListContainerGoodDto
    {
        public string HsCode { get; set; }
        public string PackageTypeCode { get; set; }
        public string Description { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal Weight { get; set; }
    }
}
