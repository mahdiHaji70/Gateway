namespace TDM.Infrastructure.Integrations.Responses
{
    public class StorageAgreementResponseDto
    {
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; } = default!;
        public string No { get; set; } = default!;
        public Guid TerminalId { get; set; }
        public string Terminal { get; set; } = default!;
        public Guid PortId { get; set; }
        public string Port { get; set; } = default!;
        public DateTime Date { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CustomsProcedureId { get; set; }
        public string CustomsProcedureCode { get; set; } = default!;
        public string CustomsProcedure { get; set; } = default!;
        public Guid CountryOriginId { get; set; }
        public string CountryOrigin { get; set; } = default!;
        public string CityOrigin { get; set; } = default!;
        public Guid? CityOriginId { get; set; }
        public Guid? CountryDestinationId { get; set; }
        public string CountryDestination { get; set; } = default!;
        public string CargoOwnerName { get; set; } = default!;
        public string CargoOwnerIdNumber { get; set; } = default!;
        public string CargoOwnerCellPhone { get; set; } = default!;
        public DateTime CargoOwnerBirthDate { get; set; }
        public string CargoOwnerEmail { get; set; } = default!;
        public string CargoOwnerPostalCode { get; set; } = default!;
        public string CargoOwnerAddress { get; set; } = default!;
        public string CargoOwnerType { get; set; } = default!;
        public string CargoOwnerTypeName { get; set; } = default!;
        public string CargoOwnerInquiryState { get; set; } = default!;
        public string CargoOwnerShortMessageSendingStatus { get; set; } = default!;
        public string CargoOwnerInquiryStateError { get; set; } = default!;
        public string CargoOwnerShortMessageSendingStatusError { get; set; } = default!;
        public string CargoOwnerMobileNumberInqueryStatus { get; set; } = default!;
        public int? CargoOwnerRepPartyId { get; set; }
        public string CargoOwnerRepName { get; set; } = default!;
        public string CargoOwnerRepIdNumber { get; set; } = default!;
        public string CargoOwnerRepCellPhone { get; set; } = default!;
        public DateTime? CargoOwnerRepBirthDate { get; set; }
        public string CargoOwnerRepEmail { get; set; } = default!;
        public string CargoOwnerRepPostalCode { get; set; } = default!;
        public string CargoOwnerRepAddress { get; set; } = default!;
        public string CargoOwnerRepType { get; set; } = default!;
        public string CargoOwnerRepTypeName { get; set; } = default!;
        public string CargoOwnerRepInquiryState { get; set; } = default!;
        public string CargoOwnerRepShortMessageSendingStatus { get; set; } = default!;
        public string CargoOwnerRepInquiryStateError { get; set; } = default!;
        public string CargoOwnerRepShortMessageSendingStatusError { get; set; } = default!;
        public string CargoOwnerRepMobileNumberInqueryStatus { get; set; } = default!;
        public int? StateId { get; set; }
        public string State { get; set; }
        public Guid CreatedById { get; set; }
        public string CreatedBy { get; set; } = default!;
        public Guid? TaskId { get; set; }
        public string TaskOwnerRoleName { get; set; } = default!;
        public string TaskStage { get; set; } = default!;
        public string TaskStageName { get; set; } = default!;
        public bool? TaskIsRead { get; set; }
        public DateTime? TaskRegisterDate { get; set; }
        public string TaskRemark { get; set; } = default!;
        public Guid? CustomsPermitId { get; set; }
        public int? CustomsPermitStateId { get; set; }
        public string CustomsPermitTaskStage { get; set; } = default!;
        public string CustomsPermitTaskStageName { get; set; } = default!;
        public Guid? GoodInsuranceId { get; set; }
        public Guid? GoodInsuranceStateId { get; set; }
        public string GoodInsuranceTaskStage { get; set; } = default!;
        public string GoodInsuranceTaskStageName { get; set; } = default!;
        public Guid? GoodsEntryId { get; set; }
        public Guid? GoodsEntryStateId { get; set; }
        public List<GeneralCargoResponseDto>? CargoList { get; set; }
        public List<ContainerResponseDto>? ContainerList { get; set; }
        public List<BulkResponseDto>? BulkList { get; set; }
    }
}