using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.DTOs;
using TDM.Application.Common.Models;
using TDM.Application.Operation.WeightBridges.DTOs;

namespace TDM.Application.Operation.WeightBridges.Queries.GetWeightBridges
{
  
    public record GetWeightBridgesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<WeightBridgeDto>>;
}
