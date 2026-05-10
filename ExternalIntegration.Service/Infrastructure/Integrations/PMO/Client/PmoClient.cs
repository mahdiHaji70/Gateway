using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Config;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TOS.Services.Gateway.Infrastructure.Integrations.PMO.Requests;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client
{
    public class PmoClient : IPmoClient
    {
        private readonly IPmoRequestExecutor _requestExecutor;
        private readonly PmoServiceNames _serviceNames;
        private readonly string _userName;
        private readonly string _password;

        public PmoClient(IPmoRequestExecutor requestExecutor,
            IOptions<PmoServiceNames> serviceNames,
            IConfiguration configuration)
        {
            _requestExecutor = requestExecutor;
            _serviceNames = serviceNames.Value;
            _userName = configuration["ServiceProviderConfig:PMO:Username"]!;
            _password = configuration["ServiceProviderConfig:PMO:Password"]!;
        }
        public async Task<Response<IEnumerable<GoodwayBillResultDto>>> GetGoodwayBill(DateRangeDto dto)
        {
            var request = new PmoRequestBuilder()
            .WithCredential(_userName, _password)
            .WithService(_serviceNames.GoodwayBills)
            .WithParameters(new List<Parameter>
            {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode},
                new Parameter{ ParameterName = nameof(dto.FromDate), ParameterValue = dto.FromDate },
                new Parameter{ ParameterName = nameof(dto.ToDate), ParameterValue = dto.ToDate },

            }).Build();

            var response = await _requestExecutor.PostAsync<IEnumerable<GoodwayBillResultDto>>(request, dto.TerminalCode);

            return response;
        }

        public async Task<Response<CreateStorageAgreementResponseDto>> CreateStorageAgreement(CreateStorageAgreementDto dto)
        {
            var request = new PmoRequestBuilder()
            .WithCredential(_userName, _password)
            .WithService("ipas-StorageAgreement")
            .WithParameters(new List<Parameter>
            {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode },
                new Parameter{ ParameterName = nameof(dto.AgreementDate), ParameterValue = dto.AgreementDate  },
                new Parameter{ ParameterName = nameof(dto.StartDate ), ParameterValue = dto.StartDate  },
                new Parameter{ParameterName = nameof(dto.FinishDate), ParameterValue = dto.FinishDate},
                new Parameter{ParameterName = nameof(dto.CustomsProcedureCode), ParameterValue = dto.CustomsProcedureCode},
                new Parameter{ParameterName = nameof(dto.WorkflowRemark), ParameterValue = dto.WorkflowRemark},
                new Parameter{ParameterName =nameof(dto.Owner),ParameterValue = JsonConvert.SerializeObject(dto.Owner)},
                new Parameter { ParameterName =nameof(dto.OwnerRep),ParameterValue = JsonConvert.SerializeObject(dto.OwnerRep)}
              
            }).Build();

            var response = await _requestExecutor.PostAsync<CreateStorageAgreementResponseDto>(request, dto.TerminalCode);
            return response;
        }

    }
}
