namespace ExternalIntegration.Service.Infrastructure.Logging.Entities
{
    public class PMOLog
    {
        public long Id { get; set; }
        public string SystemName { get; set; } = null!;
        public string OperationName { get; set; } = null!;
        public string HttpMethod { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? RequestBody { get; set; }
        public string? ResponseBody { get; set; }
        public int? StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public long DurationMs { get; set; }
        public string? CorrelationId { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
