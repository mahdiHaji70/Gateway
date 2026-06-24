namespace ExternalIntegration.Service.Sync.DTOs
{
    public class GetGoodwayBillDto:TerminalBaseDto
    {
        public Guid storageAgreementId { get; set; } = default!;
    }
}
