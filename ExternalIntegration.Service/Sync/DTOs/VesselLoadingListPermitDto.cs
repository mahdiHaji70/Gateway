namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselLoadingListPermitDto
    {
        public Guid Id { get; set; }
        public Guid LoadingPermitId { get; set; }
        public Guid VesselLoadingManifestId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerIdNumber { get; set; }
        public int OwnerType { get; set; }
        public string OwnerRepName { get; set; }
        public string OwnerRepIdNumber { get; set; }
        public int OwnerRepType { get; set; }
        public Guid WarehouseReceiptId { get; set; }
        public string WarehouseReceiptNo { get; set; }
        public DateTime LoadingPermitDate { get; set; }
        public int LoadingPermitSerialNo { get; set; }
        public string LoadingPermitRemark { get; set; }
        public string GoodClassificationName { get; set; }
        public string CargoUnitiziseTypeName { get; set; }
        public List<VesselLoadingListBulkDto> BulkList { get; set; }
        public List<VesselLoadingListGeneralCargoDto> GeneralCargoList { get; set; }
        public List<VesselLoadingListContainerDto> ContainerList { get; set; }
    }
}
