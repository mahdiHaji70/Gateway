using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.VesselLoadingPermits.DTOs;

namespace TDM.Application.Doc.VesselLoadingPermits.Queries.GetVesselLoadingListByPermitId
{
    public class GetVesselLoadingListByPermitIdQueryHandler
        : IRequestHandler<GetVesselLoadingListByPermitIdQuery, VesselLoadingListDto>
    {
        private readonly IVesselLoadingPermitExternalService _externalService;

        public GetVesselLoadingListByPermitIdQueryHandler(
            IVesselLoadingPermitExternalService externalService)
        {
            _externalService = externalService;
        }

        public Task<VesselLoadingListDto> Handle(
            GetVesselLoadingListByPermitIdQuery request,
            CancellationToken cancellationToken)
        {
            return _externalService.GetVesselLoadingListByPermitId(
                request.PermitId,
                cancellationToken);
        }
    }
}
