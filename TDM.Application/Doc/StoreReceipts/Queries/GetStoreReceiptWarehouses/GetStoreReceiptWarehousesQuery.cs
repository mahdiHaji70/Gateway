using MediatR;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptWarehouses
{
    public record GetStoreReceiptWarehousesQuery(Guid StoreReceiptId)
        : IRequest<IReadOnlyList<StoreReceiptWarehouseDto>>;

    public class StoreReceiptWarehouseDto
    {
        public string StorageAreaCode { get; set; }
        public string StorageAreaName { get; set; }
        public string CommodityName { get; set; }
        public string HsCode { get; set; }
        public string PackageName { get; set; }
        public string PackageTypeCode { get; set; }
        public DateTime OperationDate { get; set; }
        public long Quantity { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
    }
}
