using MediatR;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetManifestIssuedStoreReceipts
{
    public record GetManifestIssuedStoreReceiptsQuery(Guid IpasItemId)
        : IRequest<IEnumerable<StoreReceiptHeadDto>>;
}
