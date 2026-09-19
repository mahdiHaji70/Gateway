using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.VesselLoadingPermits.DTOs;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Responses;
using TDM.Application.Doc.VesselLoadingPermits.Commands.ConfirmVesselLoadingPermit;

namespace TDM.Infrastructure.Integrations.Client
{
    public class VesselLoadingPermitExternalService : IVesselLoadingPermitExternalService
    {
        private readonly IRequestExecutor _requestExecutor;

        public VesselLoadingPermitExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }

        public async Task<VesselLoadingPermitDto> GetVesselLoadingPermitRequest(
            Guid warehouseReceiptId,
            CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<VesselLoadingPermitResponseDto>(
                "TDM",
                "GetVesselLoadingPermitRequest",
                new { warehouseReceiptId },
                cancellationToken);

            ExternalResponseHelper.EnsureSuccess(
                response,
                "GetVesselLoadingPermitRequest");

            return VesselLoadingPermitMapper.Map(response.Data!);
        }

        public async Task<bool> ConfirmVesselLoadingPermit(
            Guid id,
            string terminalCode,
            bool isApproved,
            string remark,
            CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.PostAsync<bool>(
                "PMO",
                "ConfirmVesselLoadingPermit",
                new
                {
                    Id = id,
                    TerminalCode = terminalCode,
                    IsApproved = isApproved,
                    Remark = remark
                },
                cancellationToken);

            ExternalResponseHelper.EnsureSuccess(
                response,
                "ConfirmVesselLoadingPermit");

            return response.Data;
        }
    }
}
