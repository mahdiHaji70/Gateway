using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.VesselDischarges.DTOs;


namespace TDM.Application.Operation.VesselDischarges.Queries.GetVesselDischargeById
{
    public record GetVesselDischargeByIdQuery(Guid Id) : IRequest<VesselDischargeDto>;
}
