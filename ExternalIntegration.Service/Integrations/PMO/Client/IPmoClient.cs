using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Integrations.PMO.Client
{
    public interface IPmoClient
    {
        Task<Response<IEnumerable<GoodwayBillResultDto>>> GetGoodwayBill(DateRangeDto dto);
    }
}
