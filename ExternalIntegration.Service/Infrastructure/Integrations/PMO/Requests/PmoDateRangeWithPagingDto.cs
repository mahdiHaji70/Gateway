using System.Text.Json.Serialization;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{

    public record PmoDateRangeWithPagingDto(string TerminalCode,
                                     DateTime FromDate,
                                     DateTime ToDate,
                                     [property: JsonIgnore] string PortCode,
                                     int PageIndex,
                                     int PageSize);
}
