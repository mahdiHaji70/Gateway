using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Application.Operation.VesselDischarges.DTOs;

namespace TDM.Application.Operation.VesselDischarges.Queries.GetGetVesselDischarges
{
    public record GetVesselDischargesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<VesselDischargeDto>>;
}
