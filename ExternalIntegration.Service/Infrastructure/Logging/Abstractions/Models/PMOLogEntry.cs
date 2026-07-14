namespace ExternalIntegration.Service.Infrastructure.Logging.Abstractions.Models
{
    public class PMOLogEntry
    {
        public string SystemName { get; init; } = null!;
        public string OperationName { get; init; } = null!;
        public string HttpMethod { get; init; } = null!;
        public string Url { get; init; } = null!;
        public string? RequestBody { get; init; }
        public string? ResponseBody { get; init; }
        public int? StatusCode { get; init; }
        public bool IsSuccess { get; init; }
        public string? ErrorMessage { get; init; }
        public long DurationMs { get; init; }
        public string? CorrelationId { get; init; }
        public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
    }
}
