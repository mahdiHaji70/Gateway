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
        public async Task<List<IpasStoreReceiptResponseDto>> GetStoreReceipts(string ipasDeclarationNo, CancellationToken cancellationToken)
        {
            var response = await _requestExecutor.GetAsync<List<IssueRequestResponseDto>>("TDM", "GetStoreReceiptByStorageAgreementNo",
            new
            {
                storageAgreementNo = ipasDeclarationNo
            });

            ExternalResponseHelper.EnsureSuccess(response, "GetStoreReceiptByStorageAgreementNo");

            var IpasIssueRequests = IpasIssueRequestMapper.Map(response.Data!);

            return;
        }

       
    }
}
