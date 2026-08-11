using Azure;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Manifests.DTOs;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public class ManifestExternalService : IManifestExternalService
    {
        private readonly IRequestExecutor _requestExecutor;

        public ManifestExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }

        public async Task<List<ManifestVoyageNumberDto>> GetManifestVoyageNumbers(string terminalCode, CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<List<ManifestVoyageNumberResponseDto>>("TDM", "GetManifestsNoticeNoToApprove",
             new
             {                 
                 TerminalCode = terminalCode
             });

            ExternalResponseHelper.EnsureSuccess(response, "GetManifestsNoticeNoToApprove");

            return response.Data!.Select(x => new ManifestVoyageNumberDto
            {
                ManifestId = x.ManifestId,
                VoyageNumber = x.VoyageNumber,
            }).ToList();

        }

        public async Task<ManifestDto> GetManifestById(Guid id, CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<ManifestResponseDto>("TDM", "GetManifestById",
             new
             {
                 Id = id
             });

            ExternalResponseHelper.EnsureSuccess(response, "GetManifestById");

            return ManifestMapper.Map(response.Data!);            
        }
    }
}
