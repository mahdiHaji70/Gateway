using MediatR;
using TDM.Application.Doc.LoadingPermits.DTOs;

namespace TDM.Application.Doc.LoadingPermits.Queries.GetApprovedLoadingPermitsByStoreReceiptId
{
    public record GetApprovedLoadingPermitsByStoreReceiptIdQuery(Guid StoreReceiptId)
        : IRequest<IEnumerable<LoadingPermitDto>>;
}
