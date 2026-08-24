using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas;
using TDM.Infrastructure.Integrations.Helpers;
using TDM.Infrastructure.Integrations.Mapper;

namespace TDM.Infrastructure.Integrations.Client
{
    public class VesselDischargeExternalService : IVesselDischargeExternalService
    {
        private readonly IRequestExecutor _requestExecutor;

        public VesselDischargeExternalService(IRequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }

        public async Task<List<SendVesselDischargeToIpasResponse>> SendVesselDischargeToIpas(List<SendVesselDischargeToIpasRequest> sendVesselDischargeToIpasRequests, CancellationToken cancellationToken = default)
        {
            var vesselDischargesDto = SendVesselDischargeToIpasMapper.Map(sendVesselDischargeToIpasRequests);

            var sendVesselDischargeToIpasResponses = new List<SendVesselDischargeToIpasResponse>();

            foreach (var item in vesselDischargesDto)
            {
                var response = await _requestExecutor.PostAsync<Guid>("PMO", "SendVesselDischarge", item, cancellationToken);
                if (!ExternalResponseHelper.TryEnsureSuccess(response, "Send IPAS Terminal Discharge", out var errorMessage))
                    sendVesselDischargeToIpasResponses.Add(new SendVesselDischargeToIpasResponse
                    {
                        VesselDischargeId = item.Id,
                        ErrorMessage = errorMessage
                    });
                else
                    sendVesselDischargeToIpasResponses.Add(new SendVesselDischargeToIpasResponse
                    {
                        VesselDischargeId = item.Id,
                        IpasVesselDischargeId = new Guid(response.Data.ToString())

                    });
            }
            return sendVesselDischargeToIpasResponses;
        }
    }
}
