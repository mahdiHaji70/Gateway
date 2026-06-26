using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.WeightBridges.Commands.DeleteWeightBridge
{
  
    public class DeleteWeightBridgeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteWeightBridgeCommand(Guid id)
        {
            Id = id;
        }
    }
}
