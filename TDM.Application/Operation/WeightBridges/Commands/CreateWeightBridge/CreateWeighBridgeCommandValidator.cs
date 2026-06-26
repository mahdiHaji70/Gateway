using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.Gates.Commands.CreateGate;

namespace TDM.Application.Operation.WeightBridges.Commands.CreateWeightBridge
{
   
    public class CreateWeighBridgeCommandValidator : AbstractValidator<CreateWeighBridgeCommand>
    {
        public CreateWeighBridgeCommandValidator()
        {
            RuleFor(x => x.Vehicle)
            .NotEmpty();

        }
    }
}
