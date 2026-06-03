using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;

namespace ExternalIntegration.Service.Sync.DTOs
{
    public class StorageAgreementResultDto
    {
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public string No { get; set; }
        public Guid TerminalId { get; set; }
        public string Terminal { get; set; }
        public Guid PortId { get; set; }
        public string Port { get; set; }
        public DateTime Date { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Guid CustomsProcedureId { get; set; }
        public string CustomsProcedureCode { get; set; }
        public string CustomsProcedure { get; set; }
        public Guid CountryOriginId { get; set; }
        public string CountryOrigin { get; set; }
        public string CityOrigin { get; set; }
        public Guid? CityOriginId { get; set; }
        public Guid? CountryDestinationId { get; set; }
        public string CountryDestination { get; set; }
        public string CargoOwnerName { get; set; }
        public string CargoOwnerIdNumber { get; set; }
        public string CargoOwnerCellPhone { get; set; }
        public DateTime CargoOwnerBirthDate { get; set; }
        public string CargoOwnerEmail { get; set; }
        public string CargoOwnerPostalCode { get; set; }
        public string CargoOwnerAddress { get; set; }
        public string CargoOwnerType { get; set; }
        public string CargoOwnerTypeName { get; set; }
        public string CargoOwnerInquiryState { get; set; }
        public string CargoOwnerShortMessageSendingStatus { get; set; }
        public string CargoOwnerInquiryStateError { get; set; }
        public string CargoOwnerShortMessageSendingStatusError { get; set; }
        public string CargoOwnerMobileNumberInqueryStatus { get; set; }
        public int? CargoOwnerRepPartyId { get; set; }
        public string CargoOwnerRepName { get; set; }
        public string CargoOwnerRepIdNumber { get; set; }
        public string CargoOwnerRepCellPhone { get; set; }
        public DateTime? CargoOwnerRepBirthDate { get; set; }
        public string CargoOwnerRepEmail { get; set; }
        public string CargoOwnerRepPostalCode { get; set; }
        public string CargoOwnerRepAddress { get; set; }
        public string CargoOwnerRepType { get; set; }
        public string CargoOwnerRepTypeName { get; set; }
        public string CargoOwnerRepInquiryState { get; set; }
        public string CargoOwnerRepShortMessageSendingStatus { get; set; }
        public string CargoOwnerRepInquiryStateError { get; set; }
        public string CargoOwnerRepShortMessageSendingStatusError { get; set; }
        public string CargoOwnerRepMobileNumberInqueryStatus { get; set; }
        public int? StateId { get; set; }
        public string State { get; set; }
        public Guid CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public Guid? TaskId { get; set; }
        public string TaskOwnerRoleName { get; set; }
        public string TaskStage { get; set; }
        public string TaskStageName { get; set; }
        public bool? TaskIsRead { get; set; }
        public DateTime? TaskRegisterDate { get; set; }
        public string TaskRemark { get; set; }
        public Guid? CustomsPermitId { get; set; }
        public Guid? CustomsPermitStateId { get; set; }
        public string CustomsPermitTaskStage { get; set; }
        public string CustomsPermitTaskStageName { get; set; }
        public Guid? GoodInsuranceId { get; set; }
        public Guid? GoodInsuranceStateId { get; set; }
        public string GoodInsuranceTaskStage { get; set; }
        public string GoodInsuranceTaskStageName { get; set; }
        public Guid? GoodsEntryId { get; set; }
        public Guid? GoodsEntryStateId { get; set; }
        public List<GeneralCargoResultDto> CargoList { get; set; }
        public List<ContainerResultDto> ContainerList { get; set; }
        public List<BulkResultDto> BulkList { get; set; }
       
    }
}
