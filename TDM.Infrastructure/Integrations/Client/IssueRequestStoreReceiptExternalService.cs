using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Application.Doc.IssueRequestStoreReceipt.Commands.IssueRequestConfirmation;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Requests;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Client
{
    public class IssueRequestStoreReceiptExternalService : IIssueRequestStoreReceiptExternalService
    {
        private readonly IRequestExecutor _requestExecutor;
        public IssueRequestStoreReceiptExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }
        public async Task<List<IpasIssueRequestStoreReceiptResponse>> GetIssueReceiptStoreReceipts(string ipasDeclarationNo, CancellationToken cancellationToken)
        {
            var response = await _requestExecutor.GetAsync<List<IssueRequestResponseDto>>("TDM", "GetIssueRequestByStorageAgreementNo",
            new
            {
                storageAgreementNo = ipasDeclarationNo
            });

            ExternalResponseHelper.EnsureSuccess(response, "GetIssueRequestByStorageAgreementNo");

            var IpasIssueRequests = IpasIssueRequestMapper.Map(response.Data!);

            return IpasIssueRequests;
        }

        public async Task<String> IssueRequestConfirmation(IssueRequestConfirmationRequest issueRequestConfirmationRequest, CancellationToken cancellationToken)
        {
            var issueRequestConfirmationDto = IssueRequestConfirmationMapper.Map(issueRequestConfirmationRequest);

            var response = await _requestExecutor.PostAsync<string>("PMO", "IssueRequestConfirmation", issueRequestConfirmationDto);

            ExternalResponseHelper.EnsureSuccess(response, "IssueRequestConfirmation");
            return response.Data;
        }
    }
}
