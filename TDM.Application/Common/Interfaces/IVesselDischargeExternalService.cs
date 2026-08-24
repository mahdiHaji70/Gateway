using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas;

namespace TDM.Application.Common.Interfaces
{
    public interface IVesselDischargeExternalService
    {
        Task<List<SendVesselDischargeToIpasResponse>> SendVesselDischargeToIpas(List<SendVesselDischargeToIpasRequest> sendVesselDischargeToIpasRequests, CancellationToken cancellationToken = default);
    }
}
