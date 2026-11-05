using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation;
using TDM.Application.Doc.StoreReceipts.DTOs;
using TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public class StoreReceiptExternalService : IStoreReceiptExternalService
    {
        private readonly IRequestExecutor _requestExecutor;
        public StoreReceiptExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }
        public async Task<List<StoreReceiptHeadDto>> GetStoreReceipts(string ipasDeclarationNo, CancellationToken cancellationToken)
        {
            var response = await _requestExecutor.GetAsync<List<IpasStoreReceiptResponseDto>>("TDM", "GetStoreReceiptByStorageAgreementNo",
            new
            {
                storageAgreementNo = ipasDeclarationNo
            });

            ExternalResponseHelper.EnsureSuccess(response, "GetStoreReceiptByStorageAgreementNo");
            var IpasStoreReceipts = StoreReceiptMapper.Map(response.Data!);
            return IpasStoreReceipts;
        }

        public async Task<List<StoreReceiptHeadDto>> GetStoreReceiptByBillOfLadingId(
            Guid billOfLadingId,
            CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<List<IpasStoreReceiptResponseDto>>(
                "TDM",
                "GetStoreReceiptByBillOfLadingId",
                new { billOfLadingId },
                cancellationToken);

            ExternalResponseHelper.EnsureSuccess(response, "GetStoreReceiptByBillOfLadingId");

            var receipts = StoreReceiptMapper.Map(response.Data!);
            foreach (var receipt in receipts)
            {
                receipt.DeclarationId = null;
            }

            return receipts;
        }

        public async Task<SendIpasStoreAllocationResponse> SendIpasStoreAllocation(
            SendIpasStoreAllocationRequest request,
            CancellationToken cancellationToken = default)
        {
            var dto = SendStoreAllocationToIpasMapper.Map(request);

            var response = await _requestExecutor.PostAsync<bool>("PMO", "WReceiptsAllocation", dto, cancellationToken);
            if (!ExternalResponseHelper.TryEnsureSuccess(response, "Send IPAS Store Allocation", out var errorMessage))
                return new()
                {
                    StoreReceiptId = request.StoreReceiptId,
                    ErrorMessage = errorMessage,
                    IsSent = false
                };

            return new()
            {
                StoreReceiptId = request.StoreReceiptId,
                IsSent = response.Data
            };
        }

       
    }
}
