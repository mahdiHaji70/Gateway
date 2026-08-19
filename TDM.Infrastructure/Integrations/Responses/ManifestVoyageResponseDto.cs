using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Infrastructure.Integrations.Responses
{
    public class ManifestVoyageResponseDto
    {
        public string Type { get; set; }
        public string VoyageNo { get; set; }
        public string NoticeNo { get; set; }
        public DateTime NoticeDate { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string LocalPortCode { get; set; }
        public bool IsContainerized { get; set; }
        public string PortOfLoadingCode { get; set; }
        public string PortOfDischargeCode { get; set; }
        public string LastPortCode { get; set; }
        public string NextPortCode { get; set; }
        public Guid ShippingLineId { get; set; }
        public string ShippingLine { get; set; }
        public string ShippingAgentCompanyIdNumber { get; set; }
        public string ShippingAgent { get; set; }
        public ManifestVoyageVesselDataResponseDto VessleData { get; set; }
    }
}
