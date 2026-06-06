using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class GeneralCargoTruckTerminalDischargeRequestDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string PackageTypeCode { get; set; }
        public string PackageType { get; set; }
        public float PackageQuantity { get; set; }
        public float GrossWeight { get; set; }
        public float NetWeight { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsDangerous { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? Length { get; set; }
        public bool IsVoluminous { get; set; }
        public DangerousSpecificationRequestDto DangerousSpecification { get; set; }
        public string Remark { get; set; }
    }
}
