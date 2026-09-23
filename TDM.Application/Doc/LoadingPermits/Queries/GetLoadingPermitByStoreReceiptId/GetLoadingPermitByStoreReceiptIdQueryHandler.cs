using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.LoadingPermits.DTOs;

namespace TDM.Application.Doc.LoadingPermits.Queries.GetLoadingPermitByStoreReceiptId
{
    public class GetLoadingPermitByStoreReceiptIdQueryHandler
        : IRequestHandler<GetLoadingPermitByStoreReceiptIdQuery, LoadingPermitDto>
    {
        private readonly ILoadingPermitExternalService _externalService;

        public GetLoadingPermitByStoreReceiptIdQueryHandler(
            ILoadingPermitExternalService externalService)
        {
            _externalService = externalService;
        }

        public Task<LoadingPermitDto> Handle(
            GetLoadingPermitByStoreReceiptIdQuery request,
            CancellationToken cancellationToken)
        {
            return _externalService.GetLoadingPermitRequest(
                request.StoreReceiptId,
                cancellationToken);
        }
    }
}
