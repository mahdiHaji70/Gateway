namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public record PmoDateRangeWithInboxDto(string TerminalCode,
                               DateTime FromDate,
                               DateTime ToDate,
                               string PortCode,
                               bool InMyInbox);
}
