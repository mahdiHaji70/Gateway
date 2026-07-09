namespace ExternalIntegration.Service.Domain.Entities
{
    public class IssueRequest
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
        public string Owner { get; set; }
        public string OwnerRep { get; set; }
        public string RequestRemark { get; set; }
        public DateTime? TaskRegisterDate { get; set; }
        public string GeneralCargoList { get; set; }
        public string BulkList { get; set; }
        public string ContainerList { get; set; }
        public string StorageAgreementNo { get; set; }
        public bool IsApproved { get; set; }
    }
}
