using System;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.VesselLoadingPermits.DTOs;

namespace TDM.Application.Doc.VesselLoadingPermits.Queries.GetVesselLoaadingPermitByStoreReceiptId
{
    public class GetVesselLoaadingPermitByStoreReceiptIdQueryHandler
        : IRequestHandler<GetVesselLoaadingPermitByStoreReceiptIdQuery, VesselLoadingPermitDto>
    {
        private readonly IVesselLoadingPermitExternalService _externalService;

        public GetVesselLoaadingPermitByStoreReceiptIdQueryHandler(
            IVesselLoadingPermitExternalService externalService)
        {
            _externalService = externalService;
        }

        public Task<VesselLoadingPermitDto> Handle(
            GetVesselLoaadingPermitByStoreReceiptIdQuery request,
            CancellationToken cancellationToken)
        {
            return _externalService.GetVesselLoadingPermitRequest(
                request.StoreReceiptId,
                cancellationToken);
        }
    }
}
