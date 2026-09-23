using MediatR;
using TDM.Application.Doc.LoadingPermits.DTOs;

namespace TDM.Application.Doc.LoadingPermits.Queries.GetLoadingPermitByStoreReceiptId
{
    public record GetLoadingPermitByStoreReceiptIdQuery(Guid StoreReceiptId)
        : IRequest<LoadingPermitDto>;
}
