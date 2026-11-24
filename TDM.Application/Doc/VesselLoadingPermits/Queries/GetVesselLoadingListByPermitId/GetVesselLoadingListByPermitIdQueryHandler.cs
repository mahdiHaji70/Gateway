using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.VesselLoadingPermits.DTOs;

namespace TDM.Application.Doc.VesselLoadingPermits.Queries.GetVesselLoadingListByPermitId
{
    public class GetVesselLoadingListByPermitIdQueryHandler
        : IRequestHandler<GetVesselLoadingListByPermitIdQuery, VesselLoadingListDto>
    {
        private readonly IVesselLoadingPermitExternalService _externalService;
        private readonly IVoyageRepository _voyageRepository;

        public GetVesselLoadingListByPermitIdQueryHandler(
            IVesselLoadingPermitExternalService externalService,
            IVoyageRepository voyageRepository)
        {
            _externalService = externalService;
            _voyageRepository = voyageRepository;
        }

        public async Task<VesselLoadingListDto> Handle(
            GetVesselLoadingListByPermitIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _externalService.GetVesselLoadingListByPermitId(
                request.PermitId,
                cancellationToken);

            if (result.Voyage == null || result.Voyage.IpasVoyageId == Guid.Empty)
                throw new Exception("The vessel loading list has no valid voyage ID.");

            var voyages = await _voyageRepository.GetByIpasIdsAsync(
                new[] { result.Voyage.IpasVoyageId }, cancellationToken);
            var voyage = voyages.SingleOrDefault();
            if (voyage == null)
                throw new Exception("Voyage was not found in TDM. Synchronize voyages before requesting the vessel loading list.");

            result.VoyageId = voyage.Id;
            return result;
        }
    }
}
