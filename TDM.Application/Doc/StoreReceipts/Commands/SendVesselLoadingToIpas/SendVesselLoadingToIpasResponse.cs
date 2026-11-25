namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public class SendVesselLoadingToIpasResponse
    {
        public Guid StoreExitDocumentId { get; set; }
        public Guid? IpasVesselLoadingId { get; set; }
        public bool IsSent { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
