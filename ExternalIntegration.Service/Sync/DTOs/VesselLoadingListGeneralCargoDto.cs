namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselLoadingListGeneralCargoDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string PackageTypeCode { get; set; }
        public string PackageType { get; set; }
        public float PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsDangerous { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? Length { get; set; }
        public bool IsVoluminous { get; set; }
        public bool? NoBrandName { get; set; }
        public bool? DangerousNotNoticed { get; set; }
        public string PortOfDischarge { get; set; }
        public string PortOfDestination { get; set; }
        public string MovementType { get; set; }
        public string Remark { get; set; }
    }
}
