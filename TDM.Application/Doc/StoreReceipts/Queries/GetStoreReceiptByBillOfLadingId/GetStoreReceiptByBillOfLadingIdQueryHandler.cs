using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByBillOfLadingId
{
    public class GetStoreReceiptByBillOfLadingIdQueryHandler
        : IRequestHandler<GetStoreReceiptByBillOfLadingIdQuery, IEnumerable<StoreReceiptHeadDto>>
    {
        private readonly IStoreReceiptExternalService _externalService;

        public GetStoreReceiptByBillOfLadingIdQueryHandler(
            IStoreReceiptExternalService externalService)
        {
            _externalService = externalService;
        }

        public async Task<IEnumerable<StoreReceiptHeadDto>> Handle(
            GetStoreReceiptByBillOfLadingIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _externalService.GetStoreReceiptByBillOfLadingId(
                request.BillOfLadingId,
                cancellationToken);
        }
    }
}
