using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class IssueRequestResponseDto
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string Port { get; set; }
        public string PortCode { get; set; }
        public string Terminal { get; set; }
        public string TerminalCode { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }
        public string State { get; set; }
        public OwnerDto Owner { get; set; }
        public OwnerRepDto OwnerRep { get; set; }
        public string RequestRemark { get; set; }
        public DateTime? TaskRegisterDate { get; set; }
        public List<StoreReceiptGeneralCargoResponseDto> GeneralCargoList { get; set; }
        public List<StoreReceiptBulkResponseDto> BulkList { get; set; }
        public List<StoreReceiptContainerResponseDto> ContainerList { get; set; }
        public string StorageAgreementNo { get; set; }
    }
}
