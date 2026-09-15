using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.Manifests.DTOs
{
    public class ManifestListDto
    {
        public Guid Id { get; set; }
        public string ManifestRegistrationNumber { get; set; }
        public string VoyageNo { get; set; }
        public string NoticeNo { get; set; }
        public string ShipAgent { get; set; }
        public string VesselName { get; set; }
        public string Imo { get; set; }
        public string ManifestNo { get; set; }
        public string TrafficName { get; set; }
        public string ConsigneeName { get; set; }
        public string CargoTypeName { get; set; }
        public string HSCode { get; set; }
        public string CommodityName { get; set; }
        public string PackageName { get; set; }
        public long PackNb { get; set; }
        public decimal GrossWeight { get; set; }
        public string Container { get; set; }
    }
}
