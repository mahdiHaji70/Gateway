using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class StoreReceiptResponseDto
    {

        public Guid Id { get; set; }
        public string terminalCode { get; set; }
        public Guid PortId { get; set; }
        public string Port { get; set; }
        public string Terminal { get; set; }
        public string No { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? InquiryLastTryDate { get; set; }
        public int InquiryState { get; set; }
        public string InquiryStateName { get; set; }
        public string OwnerName { get; set; }
        public string OwnerCellPhone { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerIdNumber { get; set; }
        public string OwnerPostalCode { get; set; }
        public string OwnerAddress { get; set; }
        public DateTime? OwnerDate { get; set; }
        public int OwnerType { get; set; }
        public Guid? OwnerPartyId { get; set; }
        public string OwnerRepName { get; set; }
        public string OwnerRepIdNumber { get; set; }
        public string OwnerRepCellPhone { get; set; }
        public string OwnerRepEmail { get; set; }
        public string OwnerRepPostalCode { get; set; }
        public string OwnerRepAddress { get; set; }
        public DateTime? OwnerRepBirthDate { get; set; }
        public Guid? OwnerRepPartyId { get; set; }
        public int OwnerRepType { get; set; }
        public string GoodClassificationName { get; set; }
        public int ItemCount { get; set; }
        public decimal Quantity { get; set; }
        public decimal Quantity_Reserved { get; set; }
        public DateTime FirstDischargeDate { get; set; }
        public Guid CreatorId { get; set; }
        public string Creator { get; set; }

        public int CustomsProcedureId { get; set; }
        public string CustomsProcedure { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }
        public bool? IsActive { get; set; }
        public string customsProcedureCode { get; set; }
        public Guid? RequestId { get; set; }

        public List<StoreReceiptGeneralCargoResponseDto> GeneralCargoList { get; set; }
        public List<StoreReceiptBulkResponseDto> BulkList { get; set; }
        public List<StoreReceiptContainerResponseDto> ContainerList { get; set; }
    }
}
