using MediatR;
using TDM.Application.Common.Models;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceipts
{
    public record GetStoreReceiptsQuery(
        int PageNumber = 1, int PageSize = 10, string? Search = null,
        DateTime? DateFrom = null, DateTime? DateTo = null,
        Guid? ConsigneeId = null, Guid? ConsigneeRepId = null, Guid? TrafficId = null,
        Guid? CargoTypeId = null, string? ArrivalTypeCode = null)
        : IRequest<PagedResult<StoreReceiptHeadDto>>;
}
