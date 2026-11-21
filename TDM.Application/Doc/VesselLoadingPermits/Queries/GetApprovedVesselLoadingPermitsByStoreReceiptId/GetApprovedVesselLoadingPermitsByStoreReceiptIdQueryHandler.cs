using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.VesselLoadingPermits.DTOs;

namespace TDM.Application.Doc.VesselLoadingPermits.Queries.GetApprovedVesselLoadingPermitsByStoreReceiptId
{
    public class GetApprovedVesselLoadingPermitsByStoreReceiptIdQueryHandler
        : IRequestHandler<GetApprovedVesselLoadingPermitsByStoreReceiptIdQuery, IEnumerable<VesselLoadingPermitDto>>
    {
        private readonly IVesselLoadingPermitExternalService _externalService;

        public GetApprovedVesselLoadingPermitsByStoreReceiptIdQueryHandler(
            IVesselLoadingPermitExternalService externalService)
        {
            _externalService = externalService;
        }

        public Task<IEnumerable<VesselLoadingPermitDto>> Handle(
            GetApprovedVesselLoadingPermitsByStoreReceiptIdQuery request,
            CancellationToken cancellationToken)
        {
            return _externalService.GetApprovedVesselLoadingPermits(
                request.StoreReceiptId,
                cancellationToken);
        }
    }
}
