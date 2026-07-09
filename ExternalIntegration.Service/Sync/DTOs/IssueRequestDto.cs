namespace ExternalIntegration.Service.Sync.DTOs
{
    public class IssueRequestDto
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
        public List<StoreReceiptGeneralCargoDto> GeneralCargoList { get; set; }
        public List<StoreReceiptBulkDto> BulkList { get; set; }
        public List<StoreReceiptContainerDto> ContainerList { get; set; }
        public string StorageAgreementNo { get; set; }
    }
}
