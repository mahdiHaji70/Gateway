using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Domain.Entities
{
    public class ManifestChange
    {
        public Guid Id { get; set; }
        public string TerminalCode { get; set; }
        public decimal RevisionNo { get; set; }
        public string Port { get; set; }
        public string PortCode { get; set; }
        public DateTime Date { get; set; }
        public string Creator { get; set; }
        public string StateName { get; set; }
        public string ManifestLocalNo { get; set; }
        public string VoyageNoticeNo { get; set; }
        public Guid ShippingLineId { get; set; }
        public string ShippingLine { get; set; }
        public string ShippingAgentIdNumber { get; set; }
        public string ShippingAgent { get; set; }
        public string ChangeLogs { get; set; }
    }
}
