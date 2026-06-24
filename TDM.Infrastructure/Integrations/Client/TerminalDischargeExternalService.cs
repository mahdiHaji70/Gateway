using Azure;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;
using TDM.Infrastructure.Integrations.Requests;
using TDM.Infrastructure.Integrations.Responses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TDM.Infrastructure.Integrations.Client
{
    public class TerminalDischargeExternalService : ITerminalDischargeExternalService
    {
        private readonly IRequestExecutor _requestExecutor;
        public TerminalDischargeExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }
        public async Task<List<SendIpasTerminalDischargeResponse>> SendIpasTerminalDischarge(List<SendIpasTerminalDischargeRequest> sendIpasTerminalDischargeRequest, CancellationToken cancellationToken = default)
        {
            var terminalDischargeDto = SendIpasTerminalDischargeMapper.Map(sendIpasTerminalDischargeRequest);
          
            var sendIpasTerminalDischargeResponse = new List<SendIpasTerminalDischargeResponse>();

            foreach (var item in terminalDischargeDto)
            {
                var response = await _requestExecutor.PostAsync<Guid>("PMO", "SubmitTruckTerminalDischarge", terminalDischargeDto, cancellationToken);
                if (!ExternalResponseHelper.TryEnsureSuccess(response, "Send IPAS Terminal Discharge", out var errorMessage))
                    sendIpasTerminalDischargeResponse.Add (new SendIpasTerminalDischargeResponse 
                    { 
                        TerminalDischargeId=item.TerminalDischargeId,
                        ErrorMessage = errorMessage
                    });
                else
                    sendIpasTerminalDischargeResponse.Add(new SendIpasTerminalDischargeResponse 
                    { 
                      TerminalDischargeId = item.TerminalDischargeId, 
                      IpasTerminalDischargeId = new Guid(response.Data.ToString()) 

                    });
            }
            return sendIpasTerminalDischargeResponse;
        }

        public async Task<List<IpasGoodwayBillsResponse>> GetIpasGoodwayBills(IpasGoodwayBillsRequest ipasDeclarationItemsRequest, CancellationToken cancellationToken = default)
        {
            var response = await _requestExecutor.GetAsync<List<GoodwayBillsResponseDto>>("TDM", "GetGoodwayBillByStorageAgreementId",
             new
             {
                 storageAgreementId = ipasDeclarationItemsRequest.IpasDeclarationId,
                 TerminalCode = ipasDeclarationItemsRequest.TerminalCode!
             });

            ExternalResponseHelper.EnsureSuccess(response, "GetGoodwayBillByStorageAgreementId");

            var IpasGoodwayBills = IpasGoodwayBillMapper.Map(response.Data!);

            return IpasGoodwayBills;
        }

    }
}
