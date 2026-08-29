using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Domain.Entities
{
    public class VesselLoadingPermit
    {
        public Guid Id { get; set; }
        public Guid PortId { get; set; }
        public string Port { get; set; }
        public Guid TerminalId { get; set; }
        public string Terminal { get; set; }
        public string TerminalCode { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SerialNo { get; set; }
        public Guid CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public string Remark { get; set; }
        public Guid PartyId { get; set; }
        public string Party { get; set; }
        public string PartyIdNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }
        public int GoodClassification { get; set; }
        public string GoodClassificationName { get; set; }
        public string CargoUnitiziseTypeName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerIdNumber { get; set; }
        public int OwnerType { get; set; }
        public string OwnerRepName { get; set; }
        public string OwnerRepIdNumber { get; set; }
        public int OwnerRepType { get; set; }
        public Guid WarehouseReceiptId { get; set; }
        public string WarehouseReceiptNo { get; set; }
        public Guid TaskId { get; set; }
        public string TaskOwnerRoleName { get; set; }
        public string TaskStage { get; set; }
        public string TaskStageName { get; set; }
        public string TaskOwnerRoleNames { get; set; }
        public bool TaskIsRead { get; set; }
        public string TaskRemark { get; set; }
        public string Workflow { get; set; }
        public DateTime TaskRegisterDate { get; set; }
        public string BulkList { get; set; }
        public string GeneralCargoList { get; set; }
        public string ContainerList { get; set; }
    }
}
