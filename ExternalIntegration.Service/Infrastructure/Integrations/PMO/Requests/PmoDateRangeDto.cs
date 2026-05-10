namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public record PmoDateRangeDto(string TerminalCode,
                               DateTime FromDate,
                               DateTime ToDate,
                               string PortCode);
}
