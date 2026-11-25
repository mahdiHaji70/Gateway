namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public class SendVesselLoadingToIpasRequest
    {
        public Guid StoreExitDocumentId { get; set; }
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public Guid VoyageId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string CarrierIdNumber { get; set; } = null!;
        public int CarrierType { get; set; }
        public string TallyMan { get; set; } = null!;
        public string? Remark { get; set; }
        public List<VesselLoadingGeneralCargo> GeneralCargoList { get; set; } = [];
        public List<VesselLoadingBulk> BulkList { get; set; } = [];
        public List<VesselLoadingContainer> ContainerList { get; set; } = [];
    }
}

namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public class VesselLoadingGeneralCargo
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string PackageTypeCode { get; set; } = null!;
        public decimal PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsDangerous { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public bool IsVoluminous { get; set; }
        public string? Remark { get; set; }
    }
}

namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public class VesselLoadingBulk
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal? Volume { get; set; }
        public bool IsDangerous { get; set; }
        public string? Remark { get; set; }
    }
}

namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public class VesselLoadingContainer
    {
        public string ContainerNo { get; set; } = null!;
        public string? Remark { get; set; }
        public VesselLoadingDischargeSpecification DischargeSpecification { get; set; } = new();
    }
}

namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public class VesselLoadingDischargeSpecification
    {
        public bool IsBundled { get; set; }
        public bool IsOG { get; set; }
        public bool IsUsedSpecialEquipment { get; set; }
        public string SpecialEquipmentOwner { get; set; } = string.Empty;
        public string CraneNo { get; set; } = string.Empty;
        public string CraneDriver { get; set; } = string.Empty;
        public string TallyMan { get; set; } = string.Empty;
        public bool NoBrandName { get; set; }
        public int HandlingTypeId { get; set; }
    }
}
