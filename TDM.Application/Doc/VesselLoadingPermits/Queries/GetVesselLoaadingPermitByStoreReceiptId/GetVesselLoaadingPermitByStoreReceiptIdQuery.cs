using System;
using MediatR;
using TDM.Application.Doc.VesselLoadingPermits.DTOs;

namespace TDM.Application.Doc.VesselLoadingPermits.Queries.GetVesselLoaadingPermitByStoreReceiptId
{
    public record GetVesselLoaadingPermitByStoreReceiptIdQuery(Guid StoreReceiptId)
        : IRequest<VesselLoadingPermitDto>;
}
