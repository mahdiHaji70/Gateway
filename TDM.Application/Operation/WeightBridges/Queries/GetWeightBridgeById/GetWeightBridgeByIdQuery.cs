using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.WeightBridges.DTOs;


namespace TDM.Application.Operation.WeightBridges.Queries.GetWeightBridgeById
{
   
    public record GetWeightBridgeByIdQuery(Guid Id) : IRequest<WeightBridgeDto>;
}
