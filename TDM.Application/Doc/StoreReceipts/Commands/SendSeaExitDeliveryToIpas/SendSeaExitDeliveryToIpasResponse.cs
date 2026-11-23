namespace TDM.Application.Doc.StoreReceipts.Commands.SendSeaExitDeliveryToIpas
{
    public class SendSeaExitDeliveryToIpasResponse
    {
        public Guid StoreExitDocumentId { get; set; }
        public Guid? IpasDeliveryId { get; set; }
        public bool IsSent { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
