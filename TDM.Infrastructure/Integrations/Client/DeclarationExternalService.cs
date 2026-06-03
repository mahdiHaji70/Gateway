using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Infrastructure.Integrations.Mapper;

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
    }
}
