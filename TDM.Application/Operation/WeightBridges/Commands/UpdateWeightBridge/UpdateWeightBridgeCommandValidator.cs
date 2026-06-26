using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.WeightBridges.Commands.UpdateWeightBridge;

namespace TDM.Application.Operation.WeightBridges.Commands.UpdateWeightBridge
{
    
    public class UpdateWeightBridgeCommandValidator : AbstractValidator<UpdateWeightBridgeCommand>
    {
        public UpdateWeightBridgeCommandValidator()
        {
            RuleFor(x => x.Vehicle)
            .NotEmpty();

        }
    }
}
