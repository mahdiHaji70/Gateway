namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselLoadingDischargeSpecificationDto
    {
        public bool IsBundled { get; set; }
        public bool IsOG { get; set; }
        public bool IsUsedSpecialEquipment { get; set; }
        public string SpecialEquipmentOwner { get; set; } = null!;
        public string CraneNo { get; set; } = null!;
        public string CraneDriver { get; set; } = null!;
        public string TallyMan { get; set; } = null!;
        public bool NoBrandName { get; set; }
        public int HandlingTypeId { get; set; }
    }
}
