using TDM.Application.Common.Interfaces;
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

       
    }
}
