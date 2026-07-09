namespace ExternalIntegration.Service.Domain.Entities
{
 
    public class Voyage
    {
       
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string VoyageNo { get; set; }
        public string NoticeNo { get; set; }
        public DateTime NoticeDate { get; set; }
        public DateTime Eta { get; set; }
        public DateTime Etd { get; set; }
        public string? LocalPortCode { get; set; }
        public bool IsContainerized { get; set; }
        public string PortOfLoadingCode { get; set; }
        public string PortOfDischargeCode { get; set; }
        public string LastPortCode { get; set; }
        public string NextPortCode { get; set; }
        public Guid ShippingLineId { get; set; }
        public string ShippingLine { get; set; }
        public string ShippingAgent { get; set; }
        public string ShippingAgentCompanyIdNumber { get; set; }
        public string VesselData { get; set; }
    }
}
