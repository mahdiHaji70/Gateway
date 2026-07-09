

using System.Text.Json.Serialization;

namespace ExternalIntegration.Service.Sync.DTOs
{
    public class DateRangeWithPagingDto
    {
        public string TerminalCode { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        [JsonIgnore]
        public string PortCode { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
