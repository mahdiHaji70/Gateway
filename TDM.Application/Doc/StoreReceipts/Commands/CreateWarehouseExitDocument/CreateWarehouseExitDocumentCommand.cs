using MediatR;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateWarehouseExitDocument
{
    public class CreateWarehouseExitDocumentCommand : IRequest<Guid>
    {
        public Guid StoreReceiptId { get; set; }
        public long PackNb { get; set; }
        public decimal Weight { get; set; }
        public string VehicleNumber { get; set; } = string.Empty;
        public Guid LoadingPermitId { get; set; }
        public DateTime Date { get; set; }
    }
}
