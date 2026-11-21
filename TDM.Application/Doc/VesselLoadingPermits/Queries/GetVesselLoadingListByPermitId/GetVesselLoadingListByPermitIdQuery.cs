using MediatR;
using TDM.Application.Doc.VesselLoadingPermits.DTOs;

namespace TDM.Application.Doc.VesselLoadingPermits.Queries.GetVesselLoadingListByPermitId
{
    public record GetVesselLoadingListByPermitIdQuery(Guid PermitId)
        : IRequest<VesselLoadingListDto>;
}
