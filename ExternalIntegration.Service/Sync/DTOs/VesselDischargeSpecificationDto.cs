namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselDischargeSpecificationDto
    {
        public bool IsBundled { get; set; }
        public bool IsOG { get; set; }
        public bool IsUsedSpecialEquipment { get; set; }
        public string? SpecialEquipmentOwner { get; set; }
        public string CraneNo { get; set; } = null!;
        public string CraneDriver { get; set; } = null!;
        public string TallyMan { get; set; } = null!;
        public int HandlingTypeId { get; set; }
    }
}
