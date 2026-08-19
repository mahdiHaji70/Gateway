using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Domain.Entities
{
    public class Manifest
    {
        public Guid Id { get; set; }
        public string SerialNo { get; set; }
        public string ManifestRegistrationNumber { get; set; }
        public bool IsEDI { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool Signed { get; set; }
        public DateTime SignatureDate { get; set; }
        public string? TerminalCodeDischarge { get; set; }
        public string? TerminalCodeLoading { get; set; }
        public string NoticeNo { get; set; }
        public string VoyageNo { get; set; }
        public string Voyage { get; set; }
        public string Items { get; set; }
        public bool IsApproved { get; set; }
    }
}
