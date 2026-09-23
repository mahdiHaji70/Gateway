using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.LoadingPermits.DTOs;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public class LoadingPermitExternalService : ILoadingPermitExternalService
    {
        private readonly IRequestExecutor _requestExecutor;

        public LoadingPermitExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }

        public async Task<LoadingPermitDto> GetLoadingPermitRequest(
            Guid warehouseReceiptId,
            CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<LoadingPermitResponseDto>(
                "TDM",
                "GetLoadingPermitRequest",
                new { warehouseReceiptId },
                cancellationToken);

            ExternalResponseHelper.EnsureSuccess(response, "GetLoadingPermitRequest");
            return LoadingPermitMapper.Map(response.Data!);
        }

        public async Task<bool> ConfirmLoadingPermit(
            Guid permitId,
            string terminalCode,
            bool isApproved,
            string description,
            CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.PostAsync<bool>(
                "PMO",
                "ConfirmLoadingPermit",
                new
                {
                    PermitId = permitId,
                    TerminalCode = terminalCode,
                    IsApproved = isApproved,
                    Description = description
                },
                cancellationToken);

            ExternalResponseHelper.EnsureSuccess(response, "ConfirmLoadingPermit");
            return response.Data;
        }
    }
}
