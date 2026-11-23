namespace TDM.Application.Doc.StoreReceipts.Commands.SendLandExitDeliveryToIpas
{
    public class SendLandExitDeliveryToIpasCommandResponse
    {
        public Guid StoreExitDocumentId { get; set; }
        public Guid? IpasDeliveryId { get; set; }
        public int? IpasDeliverySerialNo { get; set; }
        public bool IsSent { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
