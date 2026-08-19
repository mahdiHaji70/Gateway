using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class ManifestResponseDto
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
        public ManifestVoyageResponseDto Voyage { get; set; }
        public List<ManifestItemResponseDto> Items { get; set; }
    }
}
