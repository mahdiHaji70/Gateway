using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
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

        public async Task<string> GetIpasDeclarationId(IpasDeclarationIdRequest ipasDeclarationIdRequest, CancellationToken cancellationToken = default)
        {
            var createStorageAgreementDto = CreateStorageAgreementMapper.Map(ipasDeclarationIdRequest);

            var ipasDeclarationResponse = await _requestExecutor.PostAsync<string>("PMO", "CreateStorageAgreement", createStorageAgreementDto, cancellationToken);

            return ipasDeclarationResponse.Data!.ToString();
        }

        public async Task<List<IpasDeclarationItemResponse>> GetIpasDeclarationItems(IpasDeclarationItemsRequest ipasDeclarationItemsRequest, CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<StorageAgreementResponseDto>("PMO", "GetStorageAgreement",
             new
             {
                 AgreementNo = ipasDeclarationItemsRequest.IpasDeclarationId,
                 TerminalCode = ipasDeclarationItemsRequest.TerminalCode!
             });

             var ipasDeclarationItems = CreateIpasDeclarationItemsResponseMapper.Map(response.Data!);

            return ipasDeclarationItems;
        }
    }
}
