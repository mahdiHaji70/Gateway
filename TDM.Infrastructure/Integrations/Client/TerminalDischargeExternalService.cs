using Azure;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;
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
        public async Task<SendIpasTerminalDischargeResponse> SendIpasTerminalDischarge(SendIpasTerminalDischargeRequest sendIpasTerminalDischargeRequest, CancellationToken cancellationToken = default)
        {
            var terminalDischargeDto = SendIpasTerminalDischargeMapper.Map(sendIpasTerminalDischargeRequest);
            var response = await _requestExecutor.PostAsync<Guid>("PMO", "SubmitTruckTerminalDischarge", terminalDischargeDto, cancellationToken);

            var sendIpasTerminalDischargeResponse = new SendIpasTerminalDischargeResponse();

            if (!ExternalResponseHelper.TryEnsureSuccess(response, "Send IPAS Terminal Discharge", out var errorMessage))
                sendIpasTerminalDischargeResponse.ErrorMessage = errorMessage;
            else
                sendIpasTerminalDischargeResponse.IpasTerminalDischargeId = new Guid(response.Data.ToString());

            return sendIpasTerminalDischargeResponse;
        }
    }
}
