using System.Globalization;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Voyages.DTOs;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public class VoyageExternalService : IVoyageExternalService
    {
        private readonly IRequestExecutor _requestExecutor;

        public VoyageExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }

        public async Task<List<VoyageSyncDto>> GetVoyagesFromDate(DateTime lastDate, CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<List<VoyageSyncResponseDto>>(
                "TDM", "GetVoyagesFromDate",
                new { lastDate = lastDate.ToString("O", CultureInfo.InvariantCulture) }, cancellationToken);

            ExternalResponseHelper.EnsureSuccess(response, "GetVoyagesFromDate");
            return (response.Data ?? []).Select(VoyageSyncMapper.Map).ToList();
        }
    }
}
