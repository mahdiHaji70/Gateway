using MediatR;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByBillOfLadingId
{
    public record GetStoreReceiptByBillOfLadingIdQuery(Guid BillOfLadingId)
        : IRequest<IEnumerable<StoreReceiptHeadDto>>;
}
