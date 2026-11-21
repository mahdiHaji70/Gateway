using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.LoadingPermits.DTOs;

namespace TDM.Application.Doc.LoadingPermits.Queries.GetApprovedLoadingPermitsByStoreReceiptId
{
    public class GetApprovedLoadingPermitsByStoreReceiptIdQueryHandler
        : IRequestHandler<GetApprovedLoadingPermitsByStoreReceiptIdQuery, IEnumerable<LoadingPermitDto>>
    {
        private readonly ILoadingPermitExternalService _externalService;

        public GetApprovedLoadingPermitsByStoreReceiptIdQueryHandler(
            ILoadingPermitExternalService externalService)
        {
            _externalService = externalService;
        }

        public Task<IEnumerable<LoadingPermitDto>> Handle(
            GetApprovedLoadingPermitsByStoreReceiptIdQuery request,
            CancellationToken cancellationToken)
        {
            return _externalService.GetApprovedLoadingPermits(
                request.StoreReceiptId,
                cancellationToken);
        }
    }
}
