using MediatR;
using TDM.Application.Common.Models;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceipts
{
    public record GetStoreReceiptsQuery(int PageNumber = 1, int PageSize = 10)
        : IRequest<PagedResult<StoreReceiptHeadDto>>;
}
