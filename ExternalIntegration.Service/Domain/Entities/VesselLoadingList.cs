namespace ExternalIntegration.Service.Domain.Entities
{
    public class VesselLoadingList
    {
        public Guid Id { get; set; }
        public string TerminalCode { get; set; }
        public string Port { get; set; }
        public string PortCode { get; set; }
        public DateTime CreationDate { get; set; }
        public string State { get; set; }
        public string Remark { get; set; }
        public string Voyage { get; set; }
        public string Permits { get; set; }
    }
}
