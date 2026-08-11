using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.Manifests.DTOs
{
    public class ManifestDto
    {
        public string SerialNo { get; set; }
        public string ManifestRegistrationNumber { get; set; }
        public string VoyageNo { get; set; }
        public string NoticeNo { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string ShipLine { get; set; }
        public string ShipAgent { get; set; }
        public string ShipAgentNationalId { get; set; }
        public string VesselName { get; set; }
        public string Imo { get; set; }
        public string TerminalCode { get; set; }
        public List<ManifestItemDto> ManifestItems { get; set; }
    }
}
