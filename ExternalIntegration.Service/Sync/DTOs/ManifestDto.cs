namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ManifestDto
    {
        public Guid Id { get; set; }
        public string SerialNo { get; set; }
        public string ManifestRegistrationNumber { get; set; }
        public bool IsEDI { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool Signed { get; set; }
        public DateTime? SignatureDate { get; set; }
        public string TerminalCodeDischarge { get; set; }
        public string TerminalCodeLoading { get; set; }
        public ManifestVoyageDto Voyage { get; set; }
        public List<ManifestItemDto> Items { get; set; }
    }
}
