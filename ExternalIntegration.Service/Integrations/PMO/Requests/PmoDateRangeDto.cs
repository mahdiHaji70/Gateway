namespace ExternalIntegration.Service.Integrations.PMO.Requests
{
    public record PmoDateRangeDto(string TerminalCode,
                               DateTime FromDate,
                               DateTime ToDate,
                               string PortCode);
}
