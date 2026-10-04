using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetManifestIssuedStoreReceipts
{
    public class GetManifestIssuedStoreReceiptsQueryHandler
        : IRequestHandler<GetManifestIssuedStoreReceiptsQuery, IEnumerable<StoreReceiptHeadDto>>
    {
        private readonly IStoreReceiptExternalService _externalService;

        public GetManifestIssuedStoreReceiptsQueryHandler(
            IStoreReceiptExternalService externalService)
        {
            _externalService = externalService;
        }

        public async Task<IEnumerable<StoreReceiptHeadDto>> Handle(
            GetManifestIssuedStoreReceiptsQuery request,
            CancellationToken cancellationToken)
        {
            return await _externalService.GetManifestIssuedStoreReceipts(
                request.IpasItemId,
                cancellationToken);
        }
    }
}
