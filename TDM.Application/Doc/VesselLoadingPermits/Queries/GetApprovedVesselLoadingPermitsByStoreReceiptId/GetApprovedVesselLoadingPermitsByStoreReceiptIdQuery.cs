using MediatR;
using TDM.Application.Doc.VesselLoadingPermits.DTOs;

namespace TDM.Application.Doc.VesselLoadingPermits.Queries.GetApprovedVesselLoadingPermitsByStoreReceiptId
{
    public record GetApprovedVesselLoadingPermitsByStoreReceiptIdQuery(Guid StoreReceiptId)
        : IRequest<IEnumerable<VesselLoadingPermitDto>>;
}
