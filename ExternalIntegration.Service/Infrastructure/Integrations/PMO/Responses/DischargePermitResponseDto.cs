namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class DischargePermitResponseDto
    {
        public string Id { get; set; }
        public string StorageAgreementId { get; set; }
        public string StorageAgreementNo { get; set; }
        public int StorageAgreementTypeId { get; set; }
        public DateTime StorageAgreementDate { get; set; }
        public string TerminalId { get; set; }
        public string Terminal { get; set; }
        public string TerminalCode { get; set; }
        public string PortId { get; set; }
        public string Port { get; set; }
        public string PortCode { get; set; }
        public DateTime Date { get; set; }
        public string Issuer { get; set; }
        public string IssuerId { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public string No { get; set; }
        public string CargoOwnerPartyId { get; set; }
        public string CargoOwnerName { get; set; }
        public string CargoOwnerIdNumber { get; set; }
        public int CargoOwnerType { get; set; }
        public string CargoOwnerRepPartyId { get; set; }
        public string CargoOwnerRepName { get; set; }
        public string CargoOwnerRepIdNumber { get; set; }
        public int CargoOwnerRepType { get; set; }
    }
}
