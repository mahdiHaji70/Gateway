namespace ExternalIntegration.Service.Sync.DTOs
{
    public record DateRangeDto(string TerminalCode,
                                 DateTime FromDate,
                                 DateTime ToDate,
                                 string PortCode);
}
