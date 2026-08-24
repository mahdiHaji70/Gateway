using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas
{
    public class SendVesselDischargeToIpasCommand : IRequest<List<SendVesselDischargeToIpasResponse>>
    {
        public Guid ManifestItemId { get; set; }

        public SendVesselDischargeToIpasCommand(Guid manifestItemId)
        {
            ManifestItemId = manifestItemId;
        }
    }
}
