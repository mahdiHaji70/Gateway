using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.VesselDischarges.Commands.DeleteVesselDischarge
{
   
    public class DeleteVesselDischargeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteVesselDischargeCommand(Guid id)
        {
            Id = id;
        }
    }
}
