using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public class DeclarationExternalService : IDeclarationExternalService
    {
        private readonly IRequestExecutor _requestExecutor;

        public DeclarationExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }

        public async Task<IpasDeclarationIdResponse> GetIpasDeclarationId(IpasDeclarationIdRequest ipasDeclarationIdRequest, CancellationToken cancellationToken = default)
        {
            var createStorageAgreementDto = CreateStorageAgreementMapper.Map(ipasDeclarationIdRequest);

            var ipasDeclarationResponse = await _requestExecutor.PostAsync<CreateStorageAgreementResultDto>("PMO", "CreateStorageAgreement", createStorageAgreementDto, cancellationToken);

            var response = new IpasDeclarationIdResponse
            {
                IpasDeclarationId = ipasDeclarationResponse.Data!.Id,
                IpasDeclarationNo = ipasDeclarationResponse.Data!.No,
            };

            return response;
        }

        public async Task<List<IpasDeclarationItemResponse>> GetIpasDeclarationItems(IpasDeclarationItemsRequest ipasDeclarationItemsRequest, CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<StorageAgreementResponseDto>("PMO", "GetStorageAgreement",
             new
             {
                 AgreementNo = ipasDeclarationItemsRequest.IpasDeclarationId,
                 TerminalCode = ipasDeclarationItemsRequest.TerminalCode!
             });

            ExternalResponseHelper.EnsureSuccess(response, "GetStorageAgreement");

            var ipasDeclarationItems = CreateIpasDeclarationItemsResponseMapper.Map(response.Data!);

            return ipasDeclarationItems;
        }
    }
}
