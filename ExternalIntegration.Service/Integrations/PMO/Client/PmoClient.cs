using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Integrations.PMO.Requests;
using ExternalIntegration.Service.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;
using TOS.Services.Gateway.Integrations.PMO.Requests;

namespace ExternalIntegration.Service.Integrations.PMO.Client
{
    public class PmoClient : IPmoClient
    {
        private readonly IPmoRequestExecutor _requestExecutor;
        private readonly string _userName;
        private readonly string _password;

        public PmoClient(IPmoRequestExecutor requestExecutor,
            IConfiguration configuration)
        {
            _requestExecutor = requestExecutor;
            _userName = configuration["ServiceProviderConfig:PMO:Username"]!;
            _password = configuration["ServiceProviderConfig:PMO:Password"]!;
        }
        public async Task<Response<IEnumerable<GoodwayBillResultDto>>> GetGoodwayBill(DateRangeDto dto)
        {
            var request = new PmoRequestBuilder()
            .WithCredential(_userName, _password)
            .WithService("ipas-GoodwayBills")
            .WithParameters(new List<Parameter>
            {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode},
                new Parameter{ ParameterName = nameof(dto.FromDate), ParameterValue = dto.FromDate },
                new Parameter{ ParameterName = nameof(dto.ToDate), ParameterValue = dto.ToDate },

            }).Build();

            var response = await _requestExecutor.PostAsync<IEnumerable<GoodwayBillResultDto>>(request, dto.TerminalCode);

            return response;
        }
    }
}
