namespace TDM.Application.Doc.StoreReceipts.Commands.SendSeaExitDeliveryToIpas
{
    public class SendSeaExitDeliveryToIpasRequest
    {
        public Guid StoreExitDocumentId { get; set; }
        public Guid LoadingPermitId { get; set; }
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleNo { get; set; } = null!;
        public DateTime LoadingStart { get; set; }
        public DateTime LoadingFinish { get; set; }
        public string? Remark { get; set; }
        public List<SeaExitDeliveryGeneralCargo> GeneralCargoList { get; set; } = [];
        public List<SeaExitDeliveryBulk> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }

    public class SeaExitDeliveryGeneralCargo
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string PackageTypeCode { get; set; } = null!;
        public string PackageType { get; set; } = null!;
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
        public bool IsHeavy { get; set; }
        public bool NoBrandName { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public string? Remark { get; set; }
        public SeaExitDeliveryDangerousSpecification DangerousSpecification { get; set; } = new();
    }

    public class SeaExitDeliveryBulk
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public string? Remark { get; set; }
        public SeaExitDeliveryDangerousSpecification DangerousSpecification { get; set; } = new();
    }

    public class SeaExitDeliveryDangerousSpecification
    {
        public string? DangerousCode { get; set; }
        public string? Classification { get; set; }
        public decimal? IgnitionTemperature { get; set; }
        public string? IgnitionTemperatureUnit { get; set; }
    }
}
